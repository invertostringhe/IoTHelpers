﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace IoTHelpers.Gpio.Modules
{
    public class MulticolorLed : GpioModuleBase
    {
        private readonly SwitchGpioModule redPin;
        private readonly SwitchGpioModule bluePin;
        private readonly SwitchGpioModule greenPin;

        public MulticolorLed(int redPinNumber,  int greenPinNumber, int bluePinNumber)
        {
            redPin = new SwitchGpioModule(Controller, redPinNumber);
            greenPin = new SwitchGpioModule(Controller, greenPinNumber);
            bluePin = new SwitchGpioModule(Controller, bluePinNumber);
        }

        public bool Red
        {
            get { return redPin.IsOn; }
            set { redPin.IsOn = value; }
        }

        public bool Green
        {
            get { return greenPin.IsOn; }
            set { greenPin.IsOn = value; }
        }

        public bool Blue
        {
            get { return bluePin.IsOn; }
            set { bluePin.IsOn = value; }
        }

        public void TurnOff()
        {
            redPin.TurnOff();
            greenPin.TurnOff();
            bluePin.TurnOff();
        }

        public void TurnWhite()
        {
            redPin.TurnOn();
            greenPin.TurnOn();
            bluePin.TurnOn();
        }

        public void TurnRed()
        {
            redPin.TurnOn();
            greenPin.TurnOff();
            bluePin.TurnOff();
        }

        public void TurnGreen()
        {
            redPin.TurnOff();
            greenPin.TurnOn();
            bluePin.TurnOff();
        }

        public void TurnBlue()
        {
            redPin.TurnOff();
            greenPin.TurnOff();
            bluePin.TurnOn();
        }
        
        public void SetColor(LEDColor color)
        {
            switch(color)
            {
                case LEDColor.Black:
                    redPin.TurnOff();
                    greenPin.TurnOff();
                    bluePin.TurnOff();
                    break;
                case LEDColor.Red:
                    redPin.TurnOn();
                    greenPin.TurnOff();
                    bluePin.TurnOff();
                    break;
                case LEDColor.Green:
                    redPin.TurnOff();
                    greenPin.TurnOn();
                    bluePin.TurnOff();
                    break;
                case LEDColor.Blue:
                    redPin.TurnOff();
                    greenPin.TurnOff();
                    bluePin.TurnOn();
                    break;
                case LEDColor.LightBlue:
                    redPin.TurnOn();
                    greenPin.TurnOff();
                    bluePin.TurnOn();
                    break;
                case LEDColor.Yellow:
                    redPin.TurnOn();
                    greenPin.TurnOn();
                    bluePin.TurnOff();
                    break;
                case LEDColor.Purple:
                    redPin.TurnOff();
                    greenPin.TurnOn();
                    bluePin.TurnOn();
                    break;
                case LEDColor.White:
                    redPin.TurnOn();
                    greenPin.TurnOn();
                    bluePin.TurnOn();
                    break;
            }
        }

        public override void Dispose()
        {
            if (redPin != null)
                redPin.Dispose();

            if (greenPin != null)
                greenPin.Dispose();

            if (bluePin != null)
                bluePin.Dispose();

            base.Dispose();
        }
    }
    
    public enum LEDColors
    {
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        LightBlue,
        Purple,
        White
    }
}

