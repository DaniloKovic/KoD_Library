   M S B A M L   `   `   `  ????P  LKoD_Library_HCI_Core6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:KoD_Library_HCI_Core6.ViewsKoD_Library_HCI_Core6.Views  5      1    +KoD_Library_HCI_Core6.Views.BookDetailsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:KoD_Library_HCI_Core6.Views     5        N? Title$  BookDetailsPage??5	       ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value??%/  '??       '?? 2    '?? y    '?? ?    ?? 5   
   " ??6   .?5      ??  ? ??$ 6q?60   ?? 5       ? ??
 ? ? ?6-   ?? 5       ? ??
 ?????6,   ?? 5       ? ??$ 28??6'   ?? 5       ? ??$ 28??6&   ?? 5       ?@d?	IsChecked$ FalseY?6*   ?? 5       ? {?$
 True??6*   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 3q?60   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 3q?60   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 3q?60   5      5      .??5      ? .+?5    
   ?? -   5         ??Name$ 
gbBookInfo??5       $??Nova Knjiga??6'   $??10,10,10,10q?6<   $??18(?6Q   $??12)?6_   $??3q?6o   
???   ?$??Visible=?6?   ?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ Vertical=?6?   .??5!      ?? -   5         ??Name$ 
stBookInfo??5!      $??20,15,20,15q?6-    ?? Orientation$ Vertical=?6B   .+?5#      ]? $??	0,10,10,0q?6   $??Stretch=?60   .+?5$      ?? $
??Left=?6   .??67   	Naslov:6@   ?? 5%      -   5        $??tbNaslovKnjige??5%      $??Stretch=?64   5&      ?? 5(      $ 
Horizontal=?6   $??0,10,0,0q?66   .+?5)      ?? .??6   Godina izdanja:6-   ?? 5*      -   5        $??tbGodinaIzdanja??5*      $	??132??65   6C   5+      ?? 5-      $ Vertical=?6   $??	0,10,10,0q?64   .+?5.      ?? .??6   Opis:6#   ?? 5/      -   5        $??tbOpis??5/      	 ?? TextWrapping$
	 Wrap=?6,   $??66??6@   50      ?? 52      $ Vertical=?6   $	??115??64   $??0,10,0,0q?6A   .+?53      ?? .??6   Autor/Autori:6+   ?? 54      $ 
Horizontal=?6!   .+?55      ?? $ 
Horizontal=?6%   $
??Left=?6>   .+?56      ?? -   5        $??cbAutori??56   '   
 ?? 
IsEditable$

 True??67   $	??275??6I   $??0,0,10,0q?6U   $
??Left=?6g   ?? 57      -   5        $??btnAddToCbAutori??57   %   $??32??6=   $??32??6I   .??58   "   ?? $[??UC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\plus.png??6(   59      5:      ?? 5<      $ 
Horizontal=?6%   $??	130,0,0,0q?6>   $??Right=?6Q   .+?5=      ?? -   5        $??chbMultipleAutor??5=   '   6c   ?? 5>      -	   5        $??cbSelectedAutori??5>   '   ${?False??6?   $	??260??6Q   5?      5@      ?? 5A      $ 
Horizontal=?6!   $??0,10,0,0q?6:   .+?5B      ?? -
   5         ??Name$ btnAddNewAutor??5B   !   $??
Novi autor??69   $	??180??6N    ? ToolTip 5C      _? 5D   "   $??Unesite novog autora??6*   5F      ?? 5G      -   5         ??Name$ tbNoviAutor??5G   "   $	??260??68   $??10,0,0,0q?6D   5H      5I      ?? 5K      $ Vertical=?6   $??0,5,0,0q?64   .+?5L      ?? .??6   Žanr/Žanrovi:6+   ?? 5M      $ 
Horizontal=?6!   .+?5N      ?? $ 
Horizontal=?6%   $
??Left=?6>   .+?5O      ?? -   5        $??	cbZanrovi??5O   '   $

 True??68   $	??275??6J   $??0,0,10,0q?6V   ?? 5P      -   5        $??btnAddToCbZanrovi??5P   %   $??32??6>   $??32??6J   .??5Q   "   ?? $[??UC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\plus.png??6(   5R      5S      ?? 5T      $ 
Horizontal=?6%   $??	130,0,0,0q?6>   $??Right=?6Q   .+?5U      ?? -   5        $??chbMultipleZanr??5U   '   6`   ?? 5V      -   5        $??cbSelectedZanrovi??5V   '   ${?False??6@   $	??260??6R   5W      5X      ?? 5Y      $ 
Horizontal=?6!   $??0,10,0,0q?6:   .+?5Z      ?? -   5        $ btnAddNewZanr??5Z   !   $??
Novi žanr??68   $	??180??6L    5[      _? 5\   "   $??Unesite novi žanr??6*   5^      ?? 5_      -   5        $ 
tbNoviZanr??5_   "   $	??260??66   $??10,0,0,0q?6B   5`      5a      ?? 5c      $ 
Horizontal=?6   $??0,15,0,0q?66   .+?5d      ?? -   5         ??Name$ 
lbKolicina??5d      .??60   
Količina:6;   ?? 5e      -   5        $ 
tbKolicina??5e      $??32??62   $??60??6>   6I   5f      ?? 5h      $ 
Horizontal=?6   $??0,10,0,0q?66   .+?5i      ?? -   5        $ lbDostupnaKolicina??5i      .??68   Dostupna Količina:6L   ?? 5j      -   5        $ tbDostupnaKolicina??5j      $??32??6:   $??60??6F   ${?False??6Q   ?? 5k      -   5        $ spDostupnost??5k   !   $ 
Horizontal=?67   $y?Visible=?6P   $
??Left=?6e   .+?5l      ?? -   5        $ lbDostupnost??5l       $??20,0,0,0q?66   .??6H   Dostupnost Knjige6[   ?? 5m      -   5         ??Name$ chbDostupnost??5m   #   5n      5o      ?? 5q      $ 
Horizontal=?6   $??	0,10,10,0q?66   $
??Left=?6I   .+?5r      ?? -   5        $??btnAddOrUpdateBook??5r      $??Dodaj novu knjigu??67   $	??Top=?6T   $??40??6?   $	??215??6?   5t      5v      5x      5y      5z      