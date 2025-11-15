using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class tempratureChanged : EventArgs
{
    public double OldTemp { get; }
    public double NewTemp { get; }
    public double Diference { get; }

    public tempratureChanged(double OldTemp, double NewTemp)
    {
        this.OldTemp = OldTemp;
        this.NewTemp = NewTemp;
        this.Diference = this.NewTemp - this.OldTemp;
    }
}

    public class ThermoState
    {
        private double OldTemp;
        private double CurrentTemp;

        public event EventHandler<tempratureChanged> OnTempChanged;

        protected virtual void RaisedTempChanged(tempratureChanged e)
        {
            if (OnTempChanged != null)
            {
                OnTempChanged?.Invoke(this, e);
            }
        }

        public void RaisedTempChanged(double OldTemp, double CurrentTemp)
        {
            RaisedTempChanged(new tempratureChanged(OldTemp, CurrentTemp));
        }

        public void SetTemperator(double NewTemp)
        {
            if (NewTemp != this.CurrentTemp)
            {
                OldTemp = this.CurrentTemp;
                this.CurrentTemp = NewTemp;
                RaisedTempChanged(OldTemp, CurrentTemp);
            }
        }
    }


    public class Desplay
    {
        public void Subscribe(ThermoState thermo)
        {
            thermo.OnTempChanged += DisplayTemp;
        }

        public void DisplayTemp(object sender, tempratureChanged e)
        {
            Console.WriteLine($"Old Temperator : {e.OldTemp}");
            Console.WriteLine($"New Temperator : {e.NewTemp}");
            Console.WriteLine($"Diference :  {e.Diference}");

        }
    }

internal class Program
{
    static void Main(string[] args)
    {
        ThermoState thermo = new ThermoState();
        Desplay desplay = new Desplay();
        desplay.Subscribe(thermo);
        thermo.SetTemperator(23);
        thermo.SetTemperator(77);
    }
}


