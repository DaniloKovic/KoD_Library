   M S B A M L   `   `   `  ????P  LKoD_Library_HCI_Core6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KoD_Library_HCI_Core6.Views.Pages!KoD_Library_HCI_Core6.Views.Pages  5      1    +KoD_Library_HCI_Core6.Views.Pages.BooksView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KoD_Library_HCI_Core6.Views.Pages     5        N? Title$  	BooksView??5       ? 	Resources 5	       ?? 
TargetType ?? Property ?? Value??%D  '??       '?? ?     '?? ?     '?? ?    ?? 5   
   " ??6   .?5      ??  ? ??$ 4q?60   ?? 5       ? ??$ 48??6'   ?? 5       ? ??$	 260??6&   ?? 5       ? ??$ 24(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 24(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$	 260??6&   ?? 5       ? ??$ 24(?6)   ?? 5       ? ??$ 4q?60   5      ?? 5   
   " ??6   .?5      ??  ? ??$	 260??6&   ?? 5       ? ??$ 24(?6)   ?? 5       ? ??$ 4q?60   5      5       .??5!      ?  ? RowDefinitions 5"   
   ?? 5#      $??9* ?6   ?? 5$      $??2* ?6    ? ColumnDefinitions 5&   
   ?? 5'      $??3* ?6   ?? 5(      .+?5*   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgKnjige??5*   5   $??0??6   $??2??6       AlternatingRowBackground
 ??ح?	   SelectionMode$	 Single=?5+      
 ?? AlternationCount$
 2??6*      AutoGenerateColumns$ False??6A   $??24(?6_      
IsReadOnly$
 True??5,      $??5,5,5,0q?6%      CanUserAddRows$ False??5-         CanUserResizeRows$ False??6*    ?? SelectedIndex$ 0??6D      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$	 Br.??6%      
Visibility$ Visible=?6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ?? *Id+6M     51      $ Naslov??6%   $??Oblique$?6T    67   ?? *Naslov+6T     52      $ Autor??6%    66   ?? *Autori+  53      $
 Zanr??6%    65   ?? *	Zanrovi+4  .System.Windows.Controls.DataGridCheckBoxColumn  54      $ 	Dostupna???6)    6>   ?? *
Dostupnost+  55      $ Godina izdanja??6%    6?   ?? *GodinaIzdanja+  56      $ 	Količina??6%   -   5        dgtcKolicina??$ Visible=?56   n    69   ?? *
Kolicina+6n     57      $ Dostupna kol.??6%   -   5        dgtcDostupnaKolicina??$ Visible=?57   ?    6>   ?? *DostupnaKolicina+6?   5:      ?? 5<   
   -   5         ??Name$ spBooksFilter??5<      $??1??6,   $??0??69   $??	5,10,5,10q?6I   .+?5=      ??  ?? Orientation$ 
Horizontal=?6   .+?5>      ?? .??6   Naslov Knjige:6(   ?? 5?      -   5        $??tbBookFilterByTitle??5?      $??20(?65   $	??260??6C   6Q   ?? 5@      $??20,0,0,0q?6   .??6+   Ime Autora:68   ?? 5A      -   5         ??Name$ tbFilterByAutorName??5A      $??20(?67   $??5,0,0,0q?6E   5B      ?? 5C      $ 
Horizontal=?6   $??0,10,0,0q?62   .+?5D      ?? .??6   Naziv žanra:6&   ?? 5E      -   5        $??cbGenres??5E       ?? 
IsEditable$
 True??6+   $	??260??6=   $??20,0,0,0q?6I   6]   ?? 5F      -   5         ??Name$ btnFilterBooks??5F      $??	Pretraži??61   $??	160,0,0,0q?6a   5G      5H      ?? 5I   
   -	   5        $ 	spButtons??5I      $??1??6(   $??1??65   $??	5,10,5,10q?6E   .+?5J      ?? -
   5        $ btnPrikaziDetalje??5J      $??Prikaži detalje??6P   $??Right=?6j   ?? 5K      -   5        $ btnIznajmiKnjigu??5K      $??Iznajmi knjigu??6O   $
{?True??6h   $??Right=?6y   $??0,5,0,0q?6?   5L      5N      5O      