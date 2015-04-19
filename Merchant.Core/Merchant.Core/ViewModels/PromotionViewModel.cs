using Cirrious.MvvmCross.ViewModels;
using Merchant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.ViewModels
{
    public class PromotionViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;
        private Promotion _promo;

        public PromotionViewModel(IDataService dataService)
        {
            _dataService = dataService;

        }

        public void Init(int index)
        {
            Index = index;
            RefreshPromotion();
        }

        private void RefreshPromotion()
        {
            Promotion promo = _dataService.GetPromotionByIndex(Index);
            if (promo == null)
                return;

            _promo = promo;
            Title = promo.Title;
            PromotionType = promo.PromotionType;
            BeginDate = promo.BeginDate;
            EndDate = promo.EndDate;
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; RaisePropertyChanged(() => Index); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        private string _promotionType;
        public string PromotionType
        {
            get { return _promotionType; }
            set { _promotionType = value; RaisePropertyChanged(() => PromotionType); }
        }

        private DateTime _beginDate;
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; RaisePropertyChanged(() => BeginDate); }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; RaisePropertyChanged(() => EndDate); }
        }

        private MvxCommand _saveCommand;

        public MvxCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new MvxCommand(ExecuteSaveCommand)); }
        }

        private void ExecuteSaveCommand()
        {
            _promo.Title = Title;
            _promo.PromotionType = PromotionType;
            _promo.BeginDate = BeginDate;
            _promo.EndDate = EndDate;

            _dataService.UpdatePromotion(_promo);

            RefreshPromotion();
        }

        private MvxCommand _clearCommand;

        public MvxCommand ClearCommand
        {
            get { return _clearCommand ?? (_clearCommand = new MvxCommand(ExecuteClearCommand)); }
        }

        private void ExecuteClearCommand()
        {
            Title = "";
            PromotionType = "";
            BeginDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;

        }

        private MvxCommand _cancelCommand;

        public MvxCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new MvxCommand(ExecuteCancelCommand)); }
        }

        private void ExecuteCancelCommand()
        {
            ShowViewModel<MainViewModel>();
        }
    }
}
