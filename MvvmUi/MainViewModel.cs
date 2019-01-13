using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MvvmUi
{
    public class MainViewModel
    {
        //only for sample
        public static MainViewModel Instance { get; } = new MainViewModel();

        public List<int> Items { get; }

        private IMoveToItem _moveToService;
        public MainViewModel()
        {
            Items = Enumerable.Range(0, 120).ToList();
            MoveToEnd = new Command(() => HandleAction());
            MoveTo = new Command(() => MoveToAction());
        }

        public ICommand MoveToEnd { get; set; }

        void HandleAction()
        {
            _moveToService.MoveTo(Items.Last() - 1);
        }

        public ICommand MoveTo { get; set; }

        private void MoveToAction()
        {
            _moveToService.MoveTo(77);
        }

        public void NavigatedTo<T>(T navagationParam) where T : IMoveToItem
        {
            _moveToService = navagationParam; 
        }
    }
}
