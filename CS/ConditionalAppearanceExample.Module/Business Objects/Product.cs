using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace ConditionalAppearanceExample.Module.Business_Objects {
   [DefaultClassOptions]
   [Appearance("CategoryColoredInListView", AppearanceItemType = "ViewItem", TargetItems = "Category", Criteria = "Category = 'Seafood'", Context = "ListView", FontColor = "Blue", Priority = 1)]
   [Appearance("RedPriceObject", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "Price>50", Context = "ListView", BackColor = "Red", FontColor = "Maroon", Priority = 2)]
   [Appearance("ActionVisibility", AppearanceItemType = "Action", TargetItems = "Product.Deactivate", Criteria = "Status = 'Inactive'", Context = "Any", Visibility = ViewItemVisibility.ShowEmptySpace)]
   [Appearance("LayoutGroupColoredInDetailView", AppearanceItemType = "LayoutItem", TargetItems = "ProductParametersLayoutGroup", Criteria = "Category = 'Seafood'", Context = "DetailView", FontColor = "Blue")]
   public class Product : BaseObject {
      public Product(Session session)
         : base(session) {
         // This constructor is used when an object is loaded from a persistent storage.
         // Do not place any code here or place it only when the IsLoading property is false:
         // if (!IsLoading){
         //    It is now OK to place your initialization code here.
         // }
         // or as an alternative, move your initialization code into the AfterConstruction method.
      }
      public override void AfterConstruction() {
         base.AfterConstruction();
         // Place here your initialization code.
      }


      private string name;
      public string Name {
         get {
            return name;
         }
         set {
            SetPropertyValue("Name", ref name, value);
         }
      }

      private decimal price;
      public decimal Price {
         get {
            return price;
         }
         set {
            SetPropertyValue("Price", ref price, value);
         }
      }

      private ProductStatus status;
      [System.ComponentModel.DefaultValue(ProductStatus.Active)]
      [ImmediatePostData]
      public ProductStatus Status {
         get {
            return status;
         }
         set {
            SetPropertyValue("Status", ref status, value);
         }
      }

      private Category category;
      [Appearance("CategoryColoredInDetailView", AppearanceItemType = "LayoutItem", TargetItems = "Category", Criteria = "Category = 'Seafood'", Context = "DetailView", FontColor = "Blue")]
      public Category Category {
         get {
            return category;
         }
         set {
            SetPropertyValue("Category", ref category, value);
         }

      }

      [Action(PredefinedCategory.RecordEdit, Caption = "Activate Product...", AutoCommit = true,
  ConfirmationMessage = "This operation will set the selected Product as Active.", TargetObjectsCriteria = "Status != 'Active'",
  SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
      public void Activate() {
         Status = ProductStatus.Active;
      }

      public const string DeactivateConfirmationMessage =
         @"This action will set the Product as inactive. There may be records in the system that continue to reference these inactive records.

         If you want to continue, click Yes.
         If you don't want to deactivate this Product, click No.";

      [Action(PredefinedCategory.RecordEdit, Caption = "Deactivate Product...", AutoCommit = true,
          ConfirmationMessage = DeactivateConfirmationMessage, TargetObjectsCriteria = "Status = 'Active'",
          SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
      public void Deactivate() {
         Status = ProductStatus.Inactive;
      }
      [Appearance("RuleMethod", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView", BackColor = "Green", FontColor = "Black")]
      public bool RuleMethod() {
         if (Price < 10 && Status == ProductStatus.Active) {
            return true;
         }
         else {
            return false;
         }
      }
      private string disabledProperty;
      [Appearance("DisableProperty", Criteria = "1=1", Enabled = false)]
      public string DisabledProperty {
         get {
            return disabledProperty;
         }
         set {
            SetPropertyValue("DisabledProperty", ref disabledProperty, value);
         }
      }

   }
   [DefaultProperty("Name")]
   public class Category : BaseObject {
      public Category(Session session)
         : base(session) {
      }
      private string name;
      public string Name {
         get {
            return name;
         }
         set {
            SetPropertyValue("Name", ref name, value);
         }
      }
   }

   public enum ProductStatus {
      Inactive = 0,
      Active = 1
   }
}
