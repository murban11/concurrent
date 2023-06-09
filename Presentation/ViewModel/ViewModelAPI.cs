﻿using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace ViewModel
{
    public class ViewModelAPI : INotifyPropertyChanged
	{
		private readonly AbstractModelAPI ModelAPI;

        private ObservableCollection<IBallModel> balls;
        public ObservableCollection<IBallModel> Balls
        {
            get { return balls; }
            set
            {
                if (value.Equals(this.balls)) return;
                balls = value;
                OnPropertyChanged("Balls");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

		public ICommand StartButton { get; set; }
        public ICommand ExitButton { get; set; }
        public string BallsNumberInput { get; set; }

		public ViewModelAPI()
		{
			ModelAPI = AbstractModelAPI.CreateAPI();
			Balls = new ObservableCollection<IBallModel>();


			StartButton = new RelayCommand(() => StartButtonHandler());
            ExitButton = new RelayCommand(() => ExitButtonHandler());

        }

        private void ExitButtonHandler()
        {
			ModelAPI.Exit();
        }

        private void StartButtonHandler()
		{
			int numberOfBalls = GetBallsNumberInput();
			ModelAPI.Start(numberOfBalls);

			for (int i = 0; i < numberOfBalls; i++)
			{
				Balls.Add(ModelAPI.GetBallModel(i));
			}
			
        }
		public int GetBallsNumberInput()
		{
			return int.TryParse(BallsNumberInput, out _) && BallsNumberInput != "0" ? int.Parse(BallsNumberInput) : 0;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
