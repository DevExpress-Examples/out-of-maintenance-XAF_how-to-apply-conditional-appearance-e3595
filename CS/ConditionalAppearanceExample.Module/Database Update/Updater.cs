using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using ConditionalAppearanceExample.Module.Business_Objects;

namespace ConditionalAppearanceExample.Module {
   public class Updater : ModuleUpdater {
      public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) {
      }
      public override void UpdateDatabaseAfterUpdateSchema() {
         base.UpdateDatabaseAfterUpdateSchema();

         Category category1 = ObjectSpace.FindObject<Category>(
CriteriaOperator.Parse("Name == 'Seafood'"));
         if (category1 == null) {
            category1 = ObjectSpace.CreateObject<Category>();
            category1.Name = "Seafood";
            category1.Save();
         }
         Category category2 = ObjectSpace.FindObject<Category>(
CriteriaOperator.Parse("Name == 'Beverages'"));
         if (category2 == null) {
            category2 = ObjectSpace.CreateObject<Category>();
            category2.Name = "Beverages";
            category2.Save();
         }
         Category category3 = ObjectSpace.FindObject<Category>(
CriteriaOperator.Parse("Name == 'Grains/Cereals'"));
         if (category3 == null) {
            category3 = ObjectSpace.CreateObject<Category>();
            category3.Name = "Grains/Cereals";
            category3.Save();
         }
         Category category4 = ObjectSpace.FindObject<Category>(
CriteriaOperator.Parse("Name == 'Dairy Products'"));
         if (category4 == null) {
            category4 = ObjectSpace.CreateObject<Category>();
            category4.Name = "Dairy Products";
            category4.Save();
         }
         Product product1 = ObjectSpace.FindObject<Product>(
            CriteriaOperator.Parse("Name == 'Boston Crab Meat'"));
         if (product1 == null) {
            product1 = ObjectSpace.CreateObject<Product>();
            product1.Name = "Boston Crab Meat";
            product1.Price = 18.40m;
            product1.Status = ProductStatus.Inactive;
            product1.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Seafood'"));
            product1.Save();
        }
         Product product2 = ObjectSpace.FindObject<Product>(
            CriteriaOperator.Parse("Name == 'Camembert Pierrot'"));
         if (product2 == null) {
            product2 = ObjectSpace.CreateObject<Product>();
            product2.Name = "Camembert Pierrot";
            product2.Price = 34m;
            product2.Status = ProductStatus.Inactive;
            product2.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Seafood'"));
            product2.Save();
         }
         Product product3 = ObjectSpace.FindObject<Product>(
   CriteriaOperator.Parse("Name == 'Carnarvon Tigers'"));
         if (product3 == null) {
            product3 = ObjectSpace.CreateObject<Product>();
            product3.Name = "Carnarvon Tigers";
            product3.Price = 62.5m;
            product3.Status = ProductStatus.Active;
            product3.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Seafood'"));
            product3.Save();
         }
         Product product4 = ObjectSpace.FindObject<Product>(
CriteriaOperator.Parse("Name == 'Chai'"));
         if (product4 == null) {
            product4 = ObjectSpace.CreateObject<Product>();
            product4.Name = "Chai";
            product4.Price = 18m;
            product4.Status = ProductStatus.Active;
            product4.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Beverages'"));
            product4.Save();
         }
         Product product5 = ObjectSpace.FindObject<Product>(
CriteriaOperator.Parse("Name == 'Filo Mix'"));
         if (product5 == null) {
            product5 = ObjectSpace.CreateObject<Product>();
            product5.Name = "Filo Mix";
            product5.Price = 7m;
            product5.Status = ProductStatus.Active;
            product5.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Grains/Cereals'"));
            product5.Save();
         }
         Product product6 = ObjectSpace.FindObject<Product>(
CriteriaOperator.Parse("Name == 'Geitost'"));
         if (product6 == null) {
            product6 = ObjectSpace.CreateObject<Product>();
            product6.Name = "Geitost";
            product6.Price = 2.5m;
            product6.Status = ProductStatus.Active;
            product6.Category = ObjectSpace.FindObject<Category>(CriteriaOperator.Parse("Name == 'Dairy Products'"));
            product6.Save();
         }
      }
   }
}
