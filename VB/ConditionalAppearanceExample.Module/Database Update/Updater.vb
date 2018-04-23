Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports ConditionalAppearanceExample.Module.Business_Objects

Namespace ConditionalAppearanceExample.Module
   Public Class Updater
       Inherits ModuleUpdater

      Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
          MyBase.New(objectSpace, currentDBVersion)
      End Sub
      Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
         MyBase.UpdateDatabaseAfterUpdateSchema()

         Dim category1 As Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Seafood'"))
         If category1 Is Nothing Then
            category1 = ObjectSpace.CreateObject(Of Category)()
            category1.Name = "Seafood"
            category1.Save()
         End If
         Dim category2 As Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Beverages'"))
         If category2 Is Nothing Then
            category2 = ObjectSpace.CreateObject(Of Category)()
            category2.Name = "Beverages"
            category2.Save()
         End If
         Dim category3 As Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Grains/Cereals'"))
         If category3 Is Nothing Then
            category3 = ObjectSpace.CreateObject(Of Category)()
            category3.Name = "Grains/Cereals"
            category3.Save()
         End If
         Dim category4 As Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Dairy Products'"))
         If category4 Is Nothing Then
            category4 = ObjectSpace.CreateObject(Of Category)()
            category4.Name = "Dairy Products"
            category4.Save()
         End If
         Dim product1 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Boston Crab Meat'"))
         If product1 Is Nothing Then
            product1 = ObjectSpace.CreateObject(Of Product)()
            product1.Name = "Boston Crab Meat"
            product1.Price = 18.40D
            product1.Status = ProductStatus.Inactive
            product1.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Seafood'"))
            product1.Save()
         End If
         Dim product2 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Camembert Pierrot'"))
         If product2 Is Nothing Then
            product2 = ObjectSpace.CreateObject(Of Product)()
            product2.Name = "Camembert Pierrot"
            product2.Price = 34D
            product2.Status = ProductStatus.Inactive
            product2.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Seafood'"))
            product2.Save()
         End If
         Dim product3 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Carnarvon Tigers'"))
         If product3 Is Nothing Then
            product3 = ObjectSpace.CreateObject(Of Product)()
            product3.Name = "Carnarvon Tigers"
            product3.Price = 62.5D
            product3.Status = ProductStatus.Active
            product3.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Seafood'"))
            product3.Save()
         End If
         Dim product4 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Chai'"))
         If product4 Is Nothing Then
            product4 = ObjectSpace.CreateObject(Of Product)()
            product4.Name = "Chai"
            product4.Price = 18D
            product4.Status = ProductStatus.Active
            product4.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Beverages'"))
            product4.Save()
         End If
         Dim product5 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Filo Mix'"))
         If product5 Is Nothing Then
            product5 = ObjectSpace.CreateObject(Of Product)()
            product5.Name = "Filo Mix"
            product5.Price = 7D
            product5.Status = ProductStatus.Active
            product5.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Grains/Cereals'"))
            product5.Save()
         End If
         Dim product6 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Geitost'"))
         If product6 Is Nothing Then
            product6 = ObjectSpace.CreateObject(Of Product)()
            product6.Name = "Geitost"
            product6.Price = 2.5D
            product6.Status = ProductStatus.Active
            product6.Category = ObjectSpace.FindObject(Of Category)(CriteriaOperator.Parse("Name == 'Dairy Products'"))
            product6.Save()
         End If
      End Sub
   End Class
End Namespace
