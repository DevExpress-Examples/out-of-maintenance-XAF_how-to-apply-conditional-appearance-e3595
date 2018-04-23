Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress.ExpressApp.Editors

Namespace ConditionalAppearanceExample.Module.Business_Objects
   <DefaultClassOptions, Appearance("CategoryColoredInListView", AppearanceItemType := "ViewItem", TargetItems := "Category", Criteria := "Category = 'Seafood'", Context := "ListView", FontColor := "Blue", Priority := 1), Appearance("RedPriceObject", AppearanceItemType := "ViewItem", TargetItems := "*", Criteria := "Price>50", Context := "ListView", BackColor := "Red", FontColor := "Maroon", Priority := 2), Appearance("ActionVisibility", AppearanceItemType := "Action", TargetItems := "Product.Deactivate", Criteria := "Status = 'Inactive'", Context := "Any", Visibility := ViewItemVisibility.ShowEmptySpace), Appearance("LayoutGroupColoredInDetailView", AppearanceItemType := "LayoutItem", TargetItems := "ProductParametersLayoutGroup", Criteria := "Category = 'Seafood'", Context := "DetailView", FontColor := "Blue")> _
   Public Class Product
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
         ' This constructor is used when an object is loaded from a persistent storage.
         ' Do not place any code here or place it only when the IsLoading property is false:
         ' if (!IsLoading){
         '    It is now OK to place your initialization code here.
         ' }
         ' or as an alternative, move your initialization code into the AfterConstruction method.
      End Sub
      Public Overrides Sub AfterConstruction()
         MyBase.AfterConstruction()
         ' Place here your initialization code.
      End Sub



      Private name_Renamed As String
      Public Property Name() As String
         Get
            Return name_Renamed
         End Get
         Set(ByVal value As String)
            SetPropertyValue("Name", name_Renamed, value)
         End Set
      End Property


      Private price_Renamed As Decimal
      Public Property Price() As Decimal
         Get
            Return price_Renamed
         End Get
         Set(ByVal value As Decimal)
            SetPropertyValue("Price", price_Renamed, value)
         End Set
      End Property


      Private status_Renamed As ProductStatus
      <System.ComponentModel.DefaultValue(ProductStatus.Active), ImmediatePostData> _
      Public Property Status() As ProductStatus
         Get
            Return status_Renamed
         End Get
         Set(ByVal value As ProductStatus)
            SetPropertyValue("Status", status_Renamed, value)
         End Set
      End Property


      Private category_Renamed As Category
      <Appearance("CategoryColoredInDetailView", AppearanceItemType := "LayoutItem", TargetItems := "Category", Criteria := "Category = 'Seafood'", Context := "DetailView", FontColor := "Blue")> _
      Public Property Category() As Category
         Get
            Return category_Renamed
         End Get
         Set(ByVal value As Category)
            SetPropertyValue("Category", category_Renamed, value)
         End Set

      End Property

      <Action(PredefinedCategory.RecordEdit, Caption := "Activate Product...", AutoCommit := True, ConfirmationMessage := "This operation will set the selected Product as Active.", TargetObjectsCriteria := "Status != 'Active'", SelectionDependencyType := MethodActionSelectionDependencyType.RequireSingleObject)> _
      Public Sub Activate()
         Status = ProductStatus.Active
      End Sub

      Public Const DeactivateConfirmationMessage As String = "This action will set the Product as inactive. There may be records in the system that continue to reference these inactive records." & ControlChars.CrLf & _
ControlChars.CrLf & _
"         If you want to continue, click Yes." & ControlChars.CrLf & _
"         If you don't want to deactivate this Product, click No."

      <Action(PredefinedCategory.RecordEdit, Caption := "Deactivate Product...", AutoCommit := True, ConfirmationMessage := DeactivateConfirmationMessage, TargetObjectsCriteria := "Status = 'Active'", SelectionDependencyType := MethodActionSelectionDependencyType.RequireSingleObject)> _
      Public Sub Deactivate()
         Status = ProductStatus.Inactive
      End Sub
      <Appearance("RuleMethod", AppearanceItemType := "ViewItem", TargetItems := "*", Context := "ListView", BackColor := "Green", FontColor := "Black")> _
      Public Function RuleMethod() As Boolean
         If Price < 10 AndAlso Status = ProductStatus.Active Then
            Return True
         Else
            Return False
         End If
      End Function

      Private disabledProperty_Renamed As String
      <Appearance("DisableProperty", Criteria := "1=1", Enabled := False)> _
      Public Property DisabledProperty() As String
         Get
            Return disabledProperty_Renamed
         End Get
         Set(ByVal value As String)
            SetPropertyValue("DisabledProperty", disabledProperty_Renamed, value)
         End Set
      End Property

   End Class
   <DefaultProperty("Name")> _
   Public Class Category
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
      End Sub

      Private name_Renamed As String
      Public Property Name() As String
         Get
            Return name_Renamed
         End Get
         Set(ByVal value As String)
            SetPropertyValue("Name", name_Renamed, value)
         End Set
      End Property
   End Class

   Public Enum ProductStatus
      Inactive = 0
      Active = 1
   End Enum
End Namespace
