using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConvertTheSpeed.ViewModels
{
    public class MainViewModel : NotifyPropertyBase
    {
        List<string> KPHSpeedLimitTextList = new() { "A", "B", "C" };
        List<string> MPHSpeedLimitTextList = new() { "a", "b", "c" };

        string SelectedSpeedUnit = "KM";

        private List<string> _comboboxItemsSourceTextList = new() { "A", "B", "C" };
        public List<string> ComboboxItemsSourceTextList
        {
            get { return _comboboxItemsSourceTextList; }
            set { SetProperty(ref _comboboxItemsSourceTextList, value); }
        }

        private string _selectedSpeedLimitText;
        public string SelectedSpeedLimitText
        {
            get { return _selectedSpeedLimitText; }
            set { SetProperty(ref _selectedSpeedLimitText, value); }
        }

        private string _lastSelectedSpeedLimitText;
        public string LastSelectedSpeedLimitText
        {
            get { return _lastSelectedSpeedLimitText; }
            set { SetProperty(ref _lastSelectedSpeedLimitText, value); }
        }

        private string _showSelectedSpeedLimitText;
        public string ShowSelectedSpeedLimitText
        {
            get { return _showSelectedSpeedLimitText; }
            set { SetProperty(ref _showSelectedSpeedLimitText, value); }
        }

        private void ChangeSpeedUnit()
        {
            if (SelectedSpeedUnit == "KM")
            {
                SelectedSpeedUnit = "Mile";
            }
            else if (SelectedSpeedUnit == "Mile")
            {
                SelectedSpeedUnit = "KM";
            }
        }

        private void ConvertSpeedLimitValue()
        {
            if (SelectedSpeedLimitText != "")
            {
                LastSelectedSpeedLimitText = SelectedSpeedLimitText;
            }
            if (SelectedSpeedUnit == "KM")
            {
                ComboboxItemsSourceTextList = KPHSpeedLimitTextList;
                switch (LastSelectedSpeedLimitText)
                {
                    case "A": SelectedSpeedLimitText = "A"; break;
                    case "B": SelectedSpeedLimitText = "B"; break;
                    case "C": SelectedSpeedLimitText = "C"; break;
                    case "a": SelectedSpeedLimitText = "A"; break;
                    case "b": SelectedSpeedLimitText = "B"; break;
                    case "c": SelectedSpeedLimitText = "C"; break;
                    default:
                        break;
                }
            }
            else if (SelectedSpeedUnit == "Mile")
            {
                ComboboxItemsSourceTextList = MPHSpeedLimitTextList;
                switch (LastSelectedSpeedLimitText)
                {
                    case "A": SelectedSpeedLimitText = "a"; break;
                    case "B": SelectedSpeedLimitText = "b"; break;
                    case "C": SelectedSpeedLimitText = "c"; break;
                    case "a": SelectedSpeedLimitText = "a"; break;
                    case "b": SelectedSpeedLimitText = "b"; break;
                    case "c": SelectedSpeedLimitText = "c"; break;
                    default:
                        break;
                }
            }
        }

        private ICommand _clickChangeSpeedUnitBtnCommand;
        public ICommand ClickChangeSpeedUnitBtnCommand
        {
            get
            {
                if (_clickChangeSpeedUnitBtnCommand == null)
                {
                    _clickChangeSpeedUnitBtnCommand = new RelayCommand((x) =>
                    {
                        ChangeSpeedUnit();
                        ConvertSpeedLimitValue();
                    }
                    );
                }
                return _clickChangeSpeedUnitBtnCommand;
            }
        }
    }
}
