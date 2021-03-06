using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;
using System;
using System.Windows.Input;

namespace Inventory_Management.ViewModel.Item
{
    public class EditItemViewModel : ViewModelBase, DocumentViewModel<Model.Item>
    {
        public EditItemViewModel(Guid id)
        {
            Document = _mongoDb.GetDocumentById<Model.Item>("Items", id);
            OnPropertyChanged(nameof(Document));
            EditCommand = new EditDocumentCommand<Model.Item>(this, this, _mongoDb, "Items");
        }

        #region prop

        public Model.Item Document { get; set; }

        public string Name
        {
            get => Document.Name;
            set
            {
                ClearErrors(nameof(Name));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Name), "Name  cannot be null.");
                }
                else
                    Document.Name = value;
            }
        }

        public double Price
        {
            get => Document.Price;
            set
            {
                ClearErrors(nameof(Price));
                if (value < 0)
                {
                    AddError(nameof(Price), "Price cannot be lower than 0.");
                }
                else
                    Document.Price = value;

            }
        }

        public double Tax
        {
            get => Document.Tax;
            set
            {
                ClearErrors(nameof(Tax));
                if (value < 0.01)
                {
                    AddError(nameof(Tax), "Tax cannot be lower than 0.");
                }
                else
                    Document.Tax = value;

            }
        }

        public int Count
        {
            get => Document.Count;
            set
            {
                ClearErrors(nameof(Count));
                if (value < 0)
                {
                    AddError(nameof(Count), "Count cannot be lower than 0.");
                }
                else
                    Document.Count = value;

            }
        }

        public DateTime? DateExpiration
        {
            get => Document.DateExpiration;
            set { Document.DateExpiration = value; }
        }


        #endregion
        public ICommand EditCommand { get; set; }
    }
}
