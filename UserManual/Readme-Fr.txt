                              =======================================================
                                  Easy Macros Version 1.3.1 - Par ORelio (c) 2013
                                        Site internet : http://microzoom.fr/
                              -------------------------------------------------------

===============
 Introduction
---------------

Merci d'avoir choisi Easy Macros ! Easy Macros est un logiciel gratuit vous permettant de définir facilement
des macros dans vos jeux et applications, et ce sans avoir besoin de disposer de matériel sophistiqué !
N'importe quel clavier peut faire l'affaire ... :-)

Comment ça marche ? Easy Macros fonctionne sur un système de scripts. Chaque script décrit le fonctionnement
d'une macro : vous choisissez la touche qui déclenche la macro et vous y associez des actions.

========================
 Maniement du logiciel
------------------------

Pour utiliser Easy Macros, il vous suffit d'extraire l'archive là où vous le désirez, puis de lancer
EasyMacros.exe : Une icône apparait dans la zone de notification en bas à droite de la barre des tâches.
Un clic droit sur cette icône vous permet de quitter le logiciel ou accéder à son interface principale.

Une fois l'interface principale d'Easy Macros ouverte, vous pouvez gérer les macros déjà présentes, les
modifier ou créer une nouvelle macro en entrant des instructions dans la zone de texte puis en cliquant sur
Sauvegarder. Les macros sont sauvegardées dans le dossier Macros et peuvent facilement être échangées avec
d'autres utilisateurs : Il suffit d'ajouter les fichiers reçus dans le dossier Macros.

Astuce : Pour lancer Easy Macros au démarrage de Windows, placez un raccourci vers EasyMacros.exe dans
le dossier suivant : C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

==========================
 Comment créer une macro
--------------------------

Le squelette d'une macro se présente comme ceci :

Macro K Application
Instruction
Instruction
Instruction
...

La première ligne constitue les en-têtes, les autres lignes les instructions : une instruction par ligne.

===============
 Les En-Têtes
---------------

Elles sont constituées de 3 informations :
 - Le type de macro
 - La touche déclencheant la macro
 - L'application cible de la macro

Les types possibles de macro sont :
 - Macro : Cette macro se déclenche avec le raccourci clavier Touche d'Activation + Touche de macro
 - SuperMacro : Cette macro se déclenche juste en appuyant sur la touche de macro
 - MouseMacro : Cette macro se déclenche avec la Touche d'Activation + un bouton de la souris
 - SuperMouseMacro : Cette macro se déclenche avec le bouton de la souris sans touche d'activation
 - RewriteMacro : Cette macro se déclenche via un raccourci clavier, en remplaçant l'action normalement effectuée
 - WinOpenMacro : Cette macro se déclenche à l'ouverture d'une fenêtre répondant aux critères
 - StartupMacro : Cette macro se déclenche au lancement du logiciel Easy Macros
 - IdleMacro : Cette macro se déclenche au bout d'un certain temps d'inactivité

La touche déclenchant la macro peut être n'importe quelle touche du clavier, ou presque
 - Pour le moment, il n'est pas possible d'associer une macro avec une touche spéciale telle que Ctrl ou Alt.
 - Dans le cas d'une macro de souris, les touches possibles sont "Left", "Right", "Middle", "Previous", "Next".
 - Dans le cas d'une macro d'ouverture de fenêtre, mettez X. La touche indiquée est ignorée mais nécessaire.
 - Dans le cas d'une macro Idle, mettez IdleMacro X où X est le temps d'inactivité en secondes.
 - Les macros Idle ne se lancent pas si une application tourne en plein écran (vidéo...)

Enfin, l'application ciblée par la macro :
 - La macro ne sera déclenchée que si la fenêtre au premier plan correspond au critère
 - Il vous suffit d'entrer un mot clé apparaissant dans le titre de la fenêtre ou bien le nom de l'exécutable.
 - Par exemple, si dans le titre de la fenêtre il est inscrit "VLC Media Player", inscrivez "VLC".
 - Vous pouvez ne pas préciser d'application ciblée. Dans ce cas la macro fonctionnera partout.
 - Vous pouvez obtenir des informations sur la fenêtre de votre choix via l'option Infos de Fenêtre

Voici quelques exemples d'en-têtes valides :
 - Macro X VLC
 - SuperMacro T explorer.exe
 - MouseMacro Right Firefox
 - SuperMouseMacro Right
 - RewriteMacro LAlt+LWin+Enter
 - WinOpenMacro X notepad.exe
 - IdleMacro 300
 - StartupMacro

===================
 Les instructions
-------------------

Une fois la macro déclenchée, les instructions sont exécutées une par une, de la première à la dernière ligne.
Les différentes instructions possibles sont :

 - Key X : Simule un appui sur la touche X du clavier
 - KeyDown X : Simule un appui sur la touche, mais sans relâcher celle-ci (Utile avec Shift, Alt ou Ctrl)
 - KeyUp X : Relâche la touche appuyée précédemment via un KeyDown

 - Mouse X : Simule un appui sur le bouton de la souris : Left, Up, Right, Previous, Next
 - MouseDown X : Simule un appui sur le bouton mais sans relâcher celui-ci
 - MouseUp X : Relâche le bouton appuyé précédemment via un MouseDown

 - Sleep n : Attend n millisecondes avant de passer à l'instruction suivante
 - Run monapplication.exe argument1 "argument 2" argument 3 etc : Lance un programme
 - Close monapplication.exe / Close Titre de la fenêtre : Ferme la fenêtre comme si on avait cliqué sur la croix
 - Kill monapplication.exe : Tue le processus indiqué (attention aux pertes de données non sauvegardées)

Pour les touches spéciales, c'est-à-dire celles ne produisant pas de caractère quand on appuie dessus,
il vous suffit d'employer les mots clés suivants pour les désigner dans votre script :

  Scroll, LShift, RShift, Shift, LCtrl, RCtrl, LAlt, RAlt, Alt, Back, Enter, Tab, Pause, Caps, Numlock,
  Escape, Space, End, Home, Left, Up, Right, Down, PrintScreen, Snapshot, Insert, Delete, WinLeft, WinRight

NB: Les touches précédées par la lettre L ou R correspondent à la touche gauche (L) ou droite (R).
Ainsi LCtrl correspond à la touche "Ctrl" située à gauche du clavier tandis que RCtrl correspond à celle de droite.

Un moyen simple de trouver le nom d'une touche est d'utiliser l'ardoise fournie dans le programme.
Une pression d'une touche affiche son nom dans l'ardoise.

Astuce: Vous pouvez préciser des coordonnées pour les actions Mouse, MouseDown, MouseUp.
Par exemple, "Mouse Left 600,420" effectuera un clic aux coordonnées 600 (horizontal) et 420 (vertical) de l'écran.

====================
 Exemple de script
--------------------

SuperMacro X VLC
Key Alt
Sleep 50
Key V
Key A

Cela effectue une capture d'écran dans le lecteur VLC.

===========================
 Historique des versions
---------------------------

Version 1.0
 - Première version d'Easy Macos
 - Permet d'associer des macros à une touche du clavier
 - Icône dans la barre des tâches, interface graphique
 - Types de macro : Macro, SuperMacro, MouseMacro, SuperMouseMacro
 - Instructions : Key, KeyDown, KeyUp, Sleep
 - Jeu complet de touches à utiliser dans les macros

Version 1.0.1
 - Correction du problème de saisie des accents circonflexes ou trémas

Version 1.1
 - Amélioré l'interface graphique : Réorganisée, plus intuitive.
 - Amélioré la détection du nom de l'éxécutable de la fenêtre active
 - Aide au premier lancement ou quand Easy Macros est déjà ouvert
 - Nouvelle macro WinOpenMacro : Se lance à l'apparition d'une fenêtre
 - Nouvelle commande Run pour les scripts de macros : lance un processus
 - Nouvelle commande Kill pour les scripts de macros : tue un processus
 - Nouvelle commande Close pour les scrips de macros : ferme une fenêtre
 - Possibilité d'ouvrir rapidement le dossier contenant les macros
 - Possibilité d'obtenir facilement les infos d'une fenêtre ouverte
 - Possibilité d'associer une macro aux boutons Milieu, Précédent, Suivant de la souris
 - Correction du problème d'encodage des caractères accentués dans un fichier de macro
 - Mise à jour de la DLL ActivityMonitor qui sert à surveiller les entrées clavier

Version 1.2
 - Nouvelle macro StartupMacro : Se lance au démarrage d'Easy Macros
 - Nouvelle macro IdleMacro : Se lance au bout d'un certain temps d'inactivité de l'utilisateur
 - Nouvelles commandes Mouse, MouseDown, MouseUp pour les scripts de macros : simule la souris

Version 1.3
 - Possibilité de déclencher les macros avec n'importe quelle touche du clavier (ou presque)
 - Possibilité de déclencher les macros avec n'importe quelle combinaison de touches du clavier
 - Possibilité d'attraper au vol la pression de touche ou combinaison de touche déclenchante
   ex : SuperMacro E notepad.exe -> exécute la macro puis écrit 'e' dans le bloc notes
   ex : RewriteMacro E notepad.exe -> exécute la macro puis ignore/mange l'appui sur la touche E
 - Possibilité d'activer ou désactiver une macro directement depuis l'interface
 - Ardoise facilitant la création de macro et de macros raccourci clavier

Version 1.3.1
 - Interface en anglais sur les systèmes Windows non français
 - Réorganisation du code source, traduction des commentaires en anglais

================
 Remerciements
----------------

Easy Macros a été conçu en utilisant les ressources suivantes :
 - UserActivityMonitor (DLL), par George Mamaladze, Article CodeProject n°7294
 - KeyboardEvents (Article), par Naren Neelamegam, Article CodeProject n°7305
 - GNOME Keyboard Shorcut (Icône), par la team GNOME, http://gnome.org/
