using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
        [SerializeField]
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public static string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public static string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

        [SerializeField]
	    public Transform stickBed;
        [SerializeField]
	    public Color pressedColor;
        [SerializeField]
	    public Color unpressedColor;
		private Vector3 m_StartPos;
	    private Vector3 m_locatedPos;
	    private Vector2 delta;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

	    private Image joyStickImg;
	    private Image stickBedImg;

		void OnEnable()
		{
			CreateVirtualAxes();
		}

        void Start()
        {
            m_locatedPos = transform.position;
            m_StartPos = transform.position;

            joyStickImg = transform.GetComponent<Image>();
            stickBedImg = stickBed.GetComponent<Image>();

            setStickColor(unpressedColor);
        }

		void UpdateVirtualAxes(Vector3 axisDelta)
		{
            axisDelta /= MovementRange;
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Update(axisDelta.x);
			}

			if (m_UseY)
			{
				m_VerticalVirtualAxis.Update(axisDelta.y);
			}
		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}


		public void OnDrag(PointerEventData data)
		{
			delta = Vector2.zero;

			if (m_UseX)
			{
			    delta.x = data.position.x - m_locatedPos.x;
			}

			if (m_UseY)
			{
			    delta.y = data.position.y - m_locatedPos.y;
			}


		    delta = Vector2.ClampMagnitude(delta, MovementRange);
		    transform.position = new Vector3(m_locatedPos.x + delta.x, m_locatedPos.y + delta.y, m_locatedPos.z);
			UpdateVirtualAxes(delta);
		}


		public void OnPointerUp(PointerEventData data)
		{
		    stickBed.position = m_StartPos;
			transform.position = m_StartPos;
			UpdateVirtualAxes(Vector3.zero);

		    setStickColor(unpressedColor);
		}


	    public void OnPointerDown(PointerEventData data)
	    {
	        m_locatedPos.x = data.position.x;
	        m_locatedPos.y = data.position.y;
	        transform.position = m_locatedPos;
	        stickBed.position = m_locatedPos;

	        setStickColor(pressedColor);
	    }

	    void setStickColor(Color clr)
	    {
	        joyStickImg.color = clr;
	        stickBedImg.color = clr;
	    }



	    void OnDisable()
		{
			// remove the joysticks from the cross platform input
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}