using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PrizeWheel
{
    public enum WheelPrizes { None, Prize100, Prize1000, Prize2000, Prize5000, PrizeX };
    public enum SpinDirections { Clockwise, AntiClockwise };

    public class WheelRotation : MonoBehaviour
    {
        #region fields
        [SerializeField] private Transform transWheel;
        [Space(5)]

        [SerializeField]
        private Text txtSelectedPrize;

        [SerializeField]
        private Toggle toggleClockWise;

        [Space(5)]
        [SerializeField]
        private float timeCoeff = 5;
        [SerializeField] private WheelSectorSettings wheelSectorSettings;
        //[SerializeField] private SpinDirections spinDirection;
        [Space(5)]

        [SerializeField]
        private AnimationCurve animationCurve;

        [SerializeField]
        private TextMesh textMesh;

        private enum WheelStates { NonSpinning, Spinning, FinishSpinning };
        private WheelStates wheelState;
        private float anglePerItem;
        private int rotationQTY;
        private int rndIndexSection;

        public SpinDirections SpinDirection
        {
            get
            {
                return toggleClockWise.isOn ? SpinDirections.Clockwise : SpinDirections.AntiClockwise;
            }
        }
        #endregion

        void Start()
        {
            wheelState = WheelStates.NonSpinning;
            anglePerItem = 360 / wheelSectorSettings.SectorsQTY;

            txtSelectedPrize.text = string.Empty;

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Spin();
            }
        }

        public void Spin()
        {
            if (wheelState == WheelStates.Spinning)
                return;

            StartCoroutine(Tools.ChangeColorAlpha(textMesh, 0, 1));

            if (transWheel.eulerAngles.z > 90)
                rotationQTY = 3;

            else
                rotationQTY = Tools.RandomInt(2, 4);


            rndIndexSection = Tools.RandomInt(0, wheelSectorSettings.SectorsQTY);
            Debug.Log("itemNumber: " + rndIndexSection);

            WheelPrizes prizeType = wheelSectorSettings.GetWheelPrize(rndIndexSection, SpinDirection);
            txtSelectedPrize.text = prizeType.ToString();

            float maxAngle = anglePerItem * rndIndexSection + 360 * rotationQTY;

            maxAngle += SpinDirection == SpinDirections.Clockwise ?
                                        Tools.RandomFloat(anglePerItem / 8, anglePerItem / 1.2F) : +Tools.RandomFloat(anglePerItem / 8, anglePerItem / 1.2F);

            StartCoroutine(IESpinTheWheel(timeCoeff * rotationQTY, maxAngle));
        }

        private IEnumerator IESpinTheWheel(float time, float maxAngle)
        {
            wheelState = WheelStates.Spinning;

            float timer = 0.0f;
            float startAngle = transWheel.eulerAngles.z;

            maxAngle = SpinDirection == SpinDirections.Clockwise ?
              -startAngle - maxAngle : maxAngle - startAngle;

            while (timer < time)
            {
                //to calculate rotation
                float angle = maxAngle * animationCurve.Evaluate(timer / time);

                transWheel.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
                timer += Time.deltaTime;
                yield return 0;
            }

            wheelState = WheelStates.NonSpinning;
            StartCoroutine(Tools.ChangeColorAlpha(textMesh, 1, 1));
        }


    }
}

