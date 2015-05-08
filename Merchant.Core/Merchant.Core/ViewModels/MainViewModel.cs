using Acr.MvvmCross.Plugins.BarCodeScanner;
using Acr.MvvmCross.Plugins.UserDialogs;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Merchant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ICalculationAmountService _amountService;
        private readonly IDataService _dataService;
        private string _promo2Title;
        private string _promo1Title;
        private string _promo3Title;
        private string _amountInCents;
        private string _amount;
        private string _inputValue;
        private string _totalSalesToday;
        private MvxCommand _transCommand;
        private MvxCommand _promo1Command;
        private MvxCommand _promo2Command;
        private MvxCommand _promo3Command;
        private MvxCommand _button1Command;
        private MvxCommand _button2Command;
        private MvxCommand _button3Command;
        private MvxCommand _button4Command;
        private MvxCommand _button5Command;
        private MvxCommand _button6Command;
        private MvxCommand _button7Command;
        private MvxCommand _button8Command;
        private MvxCommand _button9Command;
        private MvxCommand _button0Command;
        private MvxCommand _buttonCLRCommand;
        private MvxCommand _buttonDELCommand;
        private MvxCommand _saveCommand;
        private string _prevPromoTitle;
        private string _prevAmount;

        private readonly IBarCodeService _barCodeService;
        private readonly IUserDialogService _userDialogService;
        public IList<string> Formats { get; private set; }

        private string _selectedFormat;


        public MainViewModel(IBarCodeService barCodeService, IUserDialogService userDialogService,
            IDataService dataService, ICalculationAmountService amountService)
        {
            _dataService = dataService;
            _amountService = amountService;
            _barCodeService = barCodeService;
            _userDialogService = userDialogService;

            SynchronizePromotion();
            RefreshPromotion();

            InitializeVariables();
            Recalc();
            RefreshPreviousTrans();

        }

        private void RefreshPreviousTrans()
        {
            Transaction trans = _dataService.GetPreviousTransaction();

            if (trans == null)
                return;

            if (!string.IsNullOrEmpty(trans.PromoId))
                PrevPromoTitle = trans.PromoId;
            decimal ringgit = (decimal)trans.Amount / 100m;
            PrevAmount = "RM " + ringgit.ToString("0.00");
        }

        private void InitializeVariables()
        {
            var list = Enum.GetNames(typeof(BarCodeFormat)).ToList();
            list.Insert(0, "Any");
            this.Formats = list;
            this.SelectedFormat = "Any";

            _inputValue = "0";
            _amountInCents = "0";
            _amount = "0";
            PrevAmount = "";
            PrevPromoTitle = "";
        }

        /// <summary>
        /// Synchrionze Promotion from server. Currently create a dummy object
        /// </summary>
        private void SynchronizePromotion()
        {
            //var trxList = new List<Transaction>();
            for (var i = 1; i <= 3; i++)
            {
                Promotion newPromo = new Promotion
                {
                    Index = i,
                    Title = "Promotion " + i.ToString()
                };
                _dataService.InsertPromotion(newPromo);
            }
        }

        private void RefreshPromotion()
        {
            Promo1Title = _dataService.GetPromotionByIndex(1).Title;
            Promo2Title = _dataService.GetPromotionByIndex(2).Title;
            Promo3Title = _dataService.GetPromotionByIndex(3).Title;

        }

        public void Init(string userName, string qrCode)
        {
            QrMerchantName = QrPromoTitle = QrPromoType = "";

            if (string.IsNullOrEmpty(qrCode))
                return;

            var split = qrCode.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length < 4)
                return;

            QrMerchantName = split[1];
            QrPromoType = split[2];
            QrPromoTitle = split[3];

        }

        public string PrevPromoTitle
        {
            get { return _prevPromoTitle; }
            set
            {
                _prevPromoTitle = value;
                RaisePropertyChanged(() => PrevPromoTitle);
            }
        }

        public string PrevAmount
        {
            get { return _prevAmount; }
            set
            {
                _prevAmount = value;
                RaisePropertyChanged(() => PrevAmount);
            }
        }

        private string _qrPromoTitle;
        public string QrPromoTitle
        {
            get { return _qrPromoTitle; }
            set { _qrPromoTitle = value; RaisePropertyChanged(() => QrPromoTitle); }
        }

        private string _qrMerchantName;
        public string QrMerchantName
        {
            get { return _qrMerchantName; }
            set { _qrMerchantName = value; RaisePropertyChanged(() => QrMerchantName); }
        }

        private string _qrPromoType;
        public string QrPromoType
        {
            get { return _qrPromoType; }
            set { _qrPromoType = value; RaisePropertyChanged(() => QrPromoType); }
        }


        public string Promo1Title
        {
            get { return _promo1Title; }
            set { _promo1Title = value; RaisePropertyChanged(() => Promo1Title); }
        }

        public string Promo2Title
        {
            get { return _promo2Title; }
            set { _promo2Title = value; RaisePropertyChanged(() => Promo2Title); }
        }

        public string Promo3Title
        {
            get { return _promo3Title; }
            set { _promo3Title = value; RaisePropertyChanged(() => Promo3Title); }
        }


        public string AmountInCents
        {
            get { return _amountInCents; }
            set
            {
                _amountInCents = value;
                RaisePropertyChanged(() => AmountInCents);
            }
        }

        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged(() => Amount);
            }
        }

        public string InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;
                RaisePropertyChanged(() => InputValue);
                Recalc();
            }
        }

        public string TotalSalesToday
        {
            get { return _totalSalesToday; }
            set
            {
                _totalSalesToday = value;
                RaisePropertyChanged(() => TotalSalesToday);
            }
        }

        private void Recalc()
        {
            AmountInCents = _amountService.GetAmount(AmountInCents, InputValue);

            decimal cents = decimal.Parse(AmountInCents);
            decimal ringgit = cents / 100m;
            Amount = ringgit.ToString("0.00");
        }


        public IMvxCommand Scan
        {
            get
            {
                //QR Code Format @"http://www.test.com;Kedai Bunga;FREE GIFT;Buy 1 Free 1"
                //return new MvxCommand(() => ShowViewModel<MainViewModel>(new { qrCode = @"http://www.test.com;Kedai Bunga;FREE GIFT;Buy 1 Free 1" }));

                return new MvxCommand(async () =>
                {
                    var result = await _barCodeService.Read();
                    if (result.Success)
                    {
                        if (!string.IsNullOrEmpty(result.Code))
                        {
                            ShowViewModel<MainViewModel>(new { qrCode = result.Code });
                        }
                    }
                    else
                    {
                        _userDialogService.Alert("Failed to get barcode");
                    }

                });
            }
        }

        public string SelectedFormat
        {
            get { return _selectedFormat; }
            set
            {
                if (_selectedFormat == value)
                    return;

                _selectedFormat = value;
                BarCodeReadConfiguration.Default.Formats.Clear();
                if (value != "Any")
                {
                    var format = (BarCodeFormat)Enum.Parse(typeof(BarCodeFormat), value);
                    BarCodeReadConfiguration.Default.Formats.Add(format);
                }
                RaisePropertyChanged(() => this.SelectedFormat);
            }
        }


        public MvxCommand TransCommand
        {
            get { return _transCommand ?? (_transCommand = new MvxCommand(ExecuteTransCommand)); }
        }

        private void ExecuteTransCommand()
        {
            ShowViewModel<TransactionViewModel>();
        }

        public MvxCommand Promo1Command
        {
            get { return _promo1Command ?? (_promo1Command = new MvxCommand(ExecutePromo1Command)); }
        }

        private void ExecutePromo1Command()
        {
            ShowViewModel<PromotionViewModel>(new { index = 1 });
        }

        public MvxCommand Promo2Command
        {
            get { return _promo2Command ?? (_promo2Command = new MvxCommand(ExecutePromo2Command)); }
        }

        private void ExecutePromo2Command()
        {
            ShowViewModel<PromotionViewModel>(new { index = 2 });
        }


        public MvxCommand Promo3Command
        {
            get { return _promo3Command ?? (_promo3Command = new MvxCommand(ExecutePromo3Command)); }
        }

        private void ExecutePromo3Command()
        {
            ShowViewModel<PromotionViewModel>(new { index = 3 });
        }

        public MvxCommand Button1Command
        {
            get { return _button1Command ?? (_button1Command = new MvxCommand(ExecuteButton1Command)); }
        }

        private void ExecuteButton1Command()
        {
            InputValue = "1";
        }


        public MvxCommand Button2Command
        {
            get { return _button2Command ?? (_button2Command = new MvxCommand(ExecuteButton2Command)); }
        }

        private void ExecuteButton2Command()
        {
            InputValue = "2";
        }

        public MvxCommand Button3Command
        {
            get { return _button3Command ?? (_button3Command = new MvxCommand(ExecuteButton3Command)); }
        }

        private void ExecuteButton3Command()
        {
            InputValue = "3";
        }

        public MvxCommand Button4Command
        {
            get { return _button4Command ?? (_button4Command = new MvxCommand(ExecuteButton4Command)); }
        }

        private void ExecuteButton4Command()
        {
            InputValue = "4";
        }

        public MvxCommand Button5Command
        {
            get { return _button5Command ?? (_button5Command = new MvxCommand(ExecuteButton5Command)); }
        }

        private void ExecuteButton5Command()
        {
            InputValue = "5";
        }

        public MvxCommand Button6Command
        {
            get { return _button6Command ?? (_button6Command = new MvxCommand(ExecuteButton6Command)); }
        }

        private void ExecuteButton6Command()
        {
            InputValue = "6";
        }

        public MvxCommand Button7Command
        {
            get { return _button7Command ?? (_button7Command = new MvxCommand(ExecuteButton7Command)); }
        }

        private void ExecuteButton7Command()
        {
            InputValue = "7";
        }

        public MvxCommand Button8Command
        {
            get { return _button8Command ?? (_button8Command = new MvxCommand(ExecuteButton8Command)); }
        }

        private void ExecuteButton8Command()
        {
            InputValue = "8";
        }

        public MvxCommand Button9Command
        {
            get { return _button9Command ?? (_button9Command = new MvxCommand(ExecuteButton9Command)); }
        }

        private void ExecuteButton9Command()
        {
            InputValue = "9";
        }

        public MvxCommand Button0Command
        {
            get { return _button0Command ?? (_button0Command = new MvxCommand(ExecuteButton0Command)); }
        }

        private void ExecuteButton0Command()
        {
            InputValue = "0";
        }

        public MvxCommand ButtonCLRCommand
        {
            get { return _buttonCLRCommand ?? (_buttonCLRCommand = new MvxCommand(ExecuteButtonCLRCommand)); }
        }

        private void ExecuteButtonCLRCommand()
        {
            InputValue = "CLR";
        }

        public MvxCommand ButtonDELCommand
        {
            get { return _buttonDELCommand ?? (_buttonCLRCommand = new MvxCommand(ExecuteButtonDELCommand)); }
        }

        private void ExecuteButtonDELCommand()
        {
            InputValue = "DEL";
        }

        public MvxCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new MvxCommand(ExecuteSaveCommand)); }
        }

        private void ExecuteSaveCommand()
        {
            if (int.Parse(AmountInCents) == 0)
                return;
            if (string.IsNullOrEmpty(QrMerchantName))
                return;
            if (string.IsNullOrEmpty(QrPromoTitle))
                return;
            if (string.IsNullOrEmpty(QrPromoType))
                return;

            Transaction trans = new Transaction()
            {
                DateTime = DateTime.Now,
                Amount = double.Parse(AmountInCents),
                MerchantId = QrMerchantName,
                PromoId = QrPromoTitle
            };

            _dataService.InsertTransaction(trans);

            ShowViewModel<MainViewModel>();

        }
    }
}
