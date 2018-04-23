Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.ConditionalAppearance
Imports ConditionalAppearanceExample.Module.Business_Objects
Imports DevExpress.ExpressApp.Editors

Namespace ConditionalAppearanceExample.Module.Controllers
   Partial Public Class ConditionalAppearanceController
       Inherits ViewController

      Public Sub New()
         InitializeComponent()
         RegisterActions(components)
         TargetObjectType = GetType(Product)
      End Sub
      Private appearanceController As AppearanceController
      Protected Overrides Sub OnActivated()
         MyBase.OnActivated()
         appearanceController = Frame.GetController(Of AppearanceController)()
         If appearanceController IsNot Nothing Then
            AddHandler appearanceController.CustomApplyAppearance, AddressOf appearanceController_CustomApplyAppearance
            AddHandler appearanceController.AppearanceApplied, AddressOf appearanceController_AppearanceApplied
         End If
      End Sub

      Private Sub appearanceController_AppearanceApplied(ByVal sender As Object, ByVal e As ApplyAppearanceEventArgs)
         If (TypeOf View Is ListView) AndAlso (e.ItemType = AppearanceItemType.ViewItem.ToString()) AndAlso (e.ItemName = "Category") AndAlso (e.ContextObjects.Length > 0) Then
            If View.SelectedObjects.Contains(e.ContextObjects(0)) Then
               Dim formattedItem As IAppearanceFormat = TryCast(e.Item, IAppearanceFormat)
               If formattedItem IsNot Nothing Then
                  'Reset the font color of the Category property for selected objects
                  formattedItem.ResetFontColor()
               End If
            End If
         End If
      End Sub

      Protected Overridable Sub CustomizeDisabledEditorsAppearance(ByVal e As ApplyAppearanceEventArgs)
      End Sub

      Private Sub appearanceController_CustomApplyAppearance(ByVal sender As Object, ByVal e As ApplyAppearanceEventArgs)

         If e.AppearanceObject.Enabled = False Then
            'Customize the appearance of the editors disabled by a rule 
            CustomizeDisabledEditorsAppearance(e)
            'Cancel other possible conditional appearance changes,
            'applying only the rule that disables the item
            'e.Handled = true;
         End If
      End Sub
      Protected Overrides Sub OnDeactivated()
         If appearanceController IsNot Nothing Then
            RemoveHandler appearanceController.CustomApplyAppearance, AddressOf appearanceController_CustomApplyAppearance
            RemoveHandler appearanceController.AppearanceApplied, AddressOf appearanceController_AppearanceApplied
         End If
         MyBase.OnDeactivated()
      End Sub
   End Class
End Namespace
