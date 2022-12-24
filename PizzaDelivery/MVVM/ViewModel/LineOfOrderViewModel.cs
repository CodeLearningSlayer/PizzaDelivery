using PizzaDelivery.MVVM.Model;
using PizzaDelivery.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.MVVM.ViewModel
{
    class LineOfOrderViewModel : ViewModelBase
    {
        private readonly LineOfOrderService _lineOfOrderService = new LineOfOrderService();
        public ObservableCollection<LineOfOrderModel> LinesOfOrder { get; set; }

        private void GetLinesOfOrder()
        {
            LinesOfOrder = new ObservableCollection<LineOfOrderModel>(_lineOfOrderService.GetLinesOfOrder());
            foreach (var line in LinesOfOrder)
            {
                line.LineCost = _lineOfOrderService.GetLineCostByID(line.ID);
                line.OrderCode = _lineOfOrderService.GetOrderCodeByID(line.ID);
                line.PizzaCode = _lineOfOrderService.GetPizzaCodeByID(line.ID);
                line.QuantityOfPizza = _lineOfOrderService.GetPizzaQuantityByID(line.ID);
            }
        }

        public LineOfOrderViewModel()
        {
            LinesOfOrder = new ObservableCollection<LineOfOrderModel>();
            GetLinesOfOrder();
        }
    }
}
