   M S B A M L   `   `   `  ����J  Fnicolascarriere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:nicolascarrierenicolascarriere  5   	        nicolascarriere.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:nicolascarriere     5   	     � Title$  Café La Cité��5   	   $	��450��6   $	��800��6+   .��5	      �  � ShowGridLines$ false��6   $��	0,0,0,-16q�6!    � ColumnDefinitions 5
   
   �� 5      $	��75* �6   �� 5      $
��250* �6   �� 5      $
��400* �6    � RowDefinitions 5   
   �� 5      $	��75* �6   �� 5      $
��334* �6   �� 5      $	��75* �6   .+�5   
   �� $��0��6   $��0��6   $��10,10,10,10q�6.   $��/favicon.ico��6C   �� 5   
   $��Code :��6   $��0��6!   $��2��6/   $��35,23,310,0q�6?   �� 5   
   -   5         ��Name$ txtCodeEcrivable��5   &    �� TextWrapping$
 Wrap=�6   $�� ��6@   $��0��6H   $��2��6V   $��100,25,259,20q�6f   �� 5   
   -   5         ��Name$ btnChercher��5   $   $��Chercher��6   $��0��69   $��2��6G   $��196,23,147,20q�6W   6n   �� 5   
   $
��Code��6   $��1��6   $��0��6-   $��	15,20,0,0q�6=   �� 5   
   $��Boisson��6   $��1��6"   $��0��60   $��	15,80,0,0q�6@   �� 5   
   $
��Prix��6   $��1��6   $��0��6-   $��
15,140,0,0q�6=   �� 5   
   $��Taille��6   $��1��6!   $��0��6/   $��
15,200,0,0q�6?   �� 5   
   $
��Type��6   $��1��6   $��0��6-   $��
15,260,0,0q�6=   �� 5!   
   -   5        $ txtCode��5!   &   $
 Wrap=�6    �� 
IsReadOnly$
 True��67   $�� ��6I   $��1��6Q   $��1��6_   $��42,20,112,253q�6o   �� 5"   
   -   5        $ 
txtBoisson��5"   &   $
 Wrap=�6   $�� ��6:   $��1��6B   $��1��6P   $��42,80,112,193q�6`   �� 5#   
   -   5        $ txtPrix��5#   &   $
 Wrap=�6   $�� ��67   $��1��6?   $��1��6M   $��42,140,112,133q�6]   �� 5$   
   -   5         ��Name$ cbTaille��5$      $��1��6%   $��1��63   $��42,195,112,77q�6C   5&      �� 5'   
   -   5        $ cbType��5'   %   	 �� SelectedIndex$	 0��6   $��1��65   $��1��6C   $��42,255,112,16q�6S   .@�5(      �� ${�False��6   .��6-   Selectionner..6=   �� 5)      $��Froid��6   �� 5*      $��Chaud��6   5+      �� 5-   
   -   5        $ 
btnAjouter��5-   #   $��Ajouter��6   $��2��67   $��2��6E   $��15,16,250,26q�6Y   6o   �� 5.   
   -	   5        $ btnModifier��5.   $   $��Modifier��6   $��2��69   $��1��6G   $��42,16,150,26q�6W   6m   �� 5/   
   -
   5        $ btnSupprimer��5/   %   $��	Supprimer��6   $��2��6;   $��1��6I   $��146,16,24,26q�6Y   6o   &   System.Windows.Controls.DataGrid  50   
   -   5        
  Name$
 
dgCommande��50      $��2��6'   $��1��67   $��2��6D      AutoGenerateColumns$ False��6�   $��0,0,0,0q�6�      Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Code+  53      $ Boisson��6%   $ * 66    6@   �� *	Boisson+  54      $
 Prix��6%   $ * 63    6=   �� *Prix+  55      $ Taille��6%   $ * 65    6?   �� *Taille+  56      $
 Type��6%   $ * 63    6=   �� *Type+58      59      5:      