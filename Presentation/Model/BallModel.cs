using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double diameter;

        public double X {
            get { return x; }
            set { x = value; onPropertyChanged(); }
        }

        public double Y
        {
            get { return y; }
            set { y = value; onPropertyChanged(); }
        }

        public double Diameter
        {
            get { return diameter; }
            set { diameter = value; onPropertyChanged(); }
        }

        public void Move(double x, double y)
        {
            X = x;
            Y = y;
        }

        public BallModel(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.diameter = 2 * radius;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}