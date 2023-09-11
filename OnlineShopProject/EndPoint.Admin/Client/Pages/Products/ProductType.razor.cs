using Application.ViewModel;
using Application.ViewModel.Products;
using Components.Modal;

namespace EndPoint.Admin.Client.Pages.Products
{
    public partial class ProductType
    {
        public string GroupTypeName { get; set; } = string.Empty;
        private string _modalMessage = string.Empty;
        private TMModalBoxAlert? _alert;
        private TMModalBoxSuccess? _success;
        public IEnumerable<ProductTypeViewModel>? _products;

        protected override async Task OnInitializedAsync()
        {
            await LoadGrid();
        }
        private async Task  Save()
        {
            ProductTypeViewModel pt = new ProductTypeViewModel
            {
                ProductTypeName = GroupTypeName,
            };
            BaseDto result;
            //if (WorkflowStatusViewModelObject.WorkflowStatusCode == 0)
            //    result = await ProducrServices.Add("WorkflowStatus/Save", pt);
            //else
            //    result = await ProducrServices.Update("WorkflowStatus/UpdateWorkflowStatus", pt);

            result = await ProductTypeServices.Add("ProductType/Save", pt);
            _modalMessage = result.Message;

            if (result.IsSuccess)
            {
                _success?.Open();
                await LoadGrid();
            }
            else
            {
                _alert?.Open();
            }
        }

        private void OnConfirm()
        {
            _alert?.Close();
        }

        private async Task LoadGrid()
        {
            _products = await ProductTypeServices.GetAll("ProductType/Get");
        }
    }
}