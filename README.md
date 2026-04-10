# MediatekDocuments

Ce dépôt présente les fonctionnalités ajoutées à l'application d'origine disponible ici : https://github.com/CNED-SLAM/MediaTekDocuments (Le readme de ce dépôt contient la présentation de l'application d'origine).

Cette évolution a été développée en C# sous Visual Studio. Elle ajoute la gestion des commandes de livres, DVD et revues, une authentification avec gestion des droits d'accès selon le service de l'employé, l'ajout de la table suivi, des triggers et des tables service et utilisateur dans la BDD, la correction de problèmes de sécurité, le nettoyage du code avec SonarQube, l'intégration de logs, des tests unitaires et un déploiement en ligne.

## Présentation

Les fonctionnalités ajoutées sont les suivantes : gestion des commandes de livres, DVD et revues, authentification avec gestion des droits, ajout de la table suivi, des triggers et des tables service et utilisateur dans la BDD, correction des problèmes de sécurité, nettoyage SonarQube, logs Serilog, tests unitaires et déploiement en ligne.

## Authentification

L'application démarre désormais sur une fenêtre d'authentification. L'employé saisit son login et son mot de passe.

<img width="317" height="142" alt="Capture d&#39;écran 2026-04-10 091857" src="https://github.com/user-attachments/assets/2ea2b351-0742-4ebe-9d19-9eec447aa829" />


Selon son service d'appartenance, les droits d'accès sont différents.

**Service Administratif (ADM) :** accès total à toutes les fonctionnalités de l'application.

**Service Prêts (PRE) :** accès en consultation uniquement aux onglets Livres, DVD et Revues. Les onglets Parutions des revues, Commandes livres, Commandes DVD et Commandes revues sont masqués.

<img width="1102" height="858" alt="Capture d&#39;écran 2026-04-10 091944" src="https://github.com/user-attachments/assets/bc5e0d07-de11-40c6-99fe-f063812dc9ad" />


**Service Culture (CUL) :** accès refusé. Un message informe l'employé que ses droits ne sont pas suffisants, puis l'application se ferme.

<img width="471" height="163" alt="Capture d&#39;écran 2026-04-10 093902" src="https://github.com/user-attachments/assets/4d711f7a-b9b0-4566-a580-cf657f19103c" />


## Gestion des commandes de livres et DVD

Deux onglets "Commandes livres" et "Commandes DVD" ont été ajoutés. Ils permettent de :
- Rechercher un document par son numéro et afficher ses informations
- Afficher la liste des commandes triée par date (ordre inverse de la chronologie)
- Ajouter une nouvelle commande (suivi initialisé à "en cours" automatiquement)
- Modifier l'étape de suivi en respectant les règles métier (une commande livrée ou réglée ne peut pas revenir à une étape précédente, une commande ne peut pas être réglée si elle n'est pas livrée)
- Supprimer une commande uniquement si elle n'est pas encore livrée

<img width="1103" height="861" alt="Capture d&#39;écran 2026-04-10 092249" src="https://github.com/user-attachments/assets/990d5e7a-0480-43e9-a6ef-214bf615e824" />


## Gestion des commandes de revues

Un onglet "Commandes revues" a été ajouté. Il permet de :
- Rechercher une revue par son numéro et afficher ses informations
- Afficher la liste des abonnements triée par date (ordre inverse de la chronologie)
- Ajouter un nouvel abonnement
- Supprimer un abonnement uniquement si aucun exemplaire n'est rattaché

Une fenêtre d'alerte s'affiche au démarrage (service ADM uniquement) pour les abonnements expirant dans moins de 30 jours.

<img width="1101" height="856" alt="Capture d&#39;écran 2026-04-10 092415" src="https://github.com/user-attachments/assets/facf39a4-7afa-4828-a558-54ab29652c32" />


## Base de données

### Table suivi

Une table suivi a été ajoutée pour gérer les étapes de suivi des commandes de livres et DVD. Elle contient les 4 étapes suivantes :
- EC → en cours
- LI → livrée
- RE → réglée
- RL → relancée

La colonne idSuivi a été ajoutée dans la table commandedocument avec une valeur par défaut "EC" (en cours).

### Triggers

**trigger_livraison :** se déclenche automatiquement après chaque mise à jour de commandedocument. Quand une commande passe à l'état "livrée", il génère automatiquement les exemplaires correspondants dans la table exemplaire, avec un numéro séquentiel et la date de commande comme date d'achat.

**trigger_suppression :** se déclenche automatiquement avant chaque suppression dans commandedocument. Si la commande n'est pas encore livrée, il supprime les exemplaires liés avant la suppression de la commande.

### Tables service et utilisateur

Deux tables ont été ajoutées pour gérer l'authentification :
- service : contient les 3 services (ADM, PRE, CUL)
- utilisateur : contient les employés avec leur login, mot de passe et service d'appartenance

<img width="198" height="417" alt="Capture d&#39;écran 2026-04-10 092541" src="https://github.com/user-attachments/assets/d3e2cfbc-fa18-4b84-8131-1413ceb33fb0" />


## Méthode ParutionDansAbonnement

La méthode statique ParutionDansAbonnement a été ajoutée dans la classe Exemplaire du package model. Elle reçoit 3 dates en paramètre (date de commande, date de fin d'abonnement, date de parution) et retourne vrai si la date de parution est comprise entre les deux autres dates.

## Sécurité

Deux problèmes de sécurité ont été corrigés via issues et pull requests GitHub :
- Les credentials de l'API (login:pwd) ont été déplacés de Access.cs vers App.config
- Le fichier .htaccess a été modifié pour retourner une erreur 400 lors d'un appel sans paramètre à l'API

## Qualité

Le code a été nettoyé avec SonarQube for IDE. Les issues relevées ont été corrigées, à l'exception des noms des méthodes événementielles qui commencent par une minuscule (comportement normal en C# Windows Forms).

## Logs

Serilog a été intégré dans la classe Access pour enregistrer les erreurs et événements dans un fichier logs/log.txt et dans la console.

## Tests unitaires

14 tests unitaires ont été créés avec MSTest sur les classes du package model :
- AbonnementExpireTests : 1 test
- AbonnementTests : 1 test
- CategorieTests : 2 tests
- CommandeDocumentTests : 1 test
- DvdTests : 1 test
- ExemplaireTests : 1 test (ParutionDansAbonnement)
- LivreTests : 1 test
- RevueTests : 1 test
- ServiceTests : 2 tests
- SuiviTests : 2 tests
- UtilisateurTests : 1 test

<img width="1555" height="812" alt="Capture d&#39;écran 2026-04-10 044846" src="https://github.com/user-attachments/assets/f5359014-fca0-4673-b224-65d744d32391" />


## Le script de la base de données

Le script SQL se trouve à la racine du dépôt : mediatek86.sql

Les tables ajoutées par rapport à la base d'origine sont : suivi, service, utilisateur. La table commandedocument a été modifiée avec l'ajout de la colonne idSuivi.

## Installation de l'application en local

### Prérequis
- Windows 10 ou supérieur
- Visual Studio ou équivalent
- WampServer ou équivalent
- L'API REST rest_mediatekdocuments installée en local (voir dépôt : https://github.com/wrd-bnt/rest-mediatekdocuments)

### Installation
- Cloner ou télécharger le dépôt
- Ouvrir MediaTekDocuments.sln dans Visual Studio
- Avec phpMyAdmin, créer la base de données mediatek86 et importer le fichier mediatek86.sql
- Dans App.config, vérifier que l'URL pointe vers le local : `<add key="uriApi" value="http://localhost/rest_mediatekdocuments/" />`
- Lancer l'application avec **Démarrer**

Les identifiants de connexion sont fournis dans la fiche de réalisation professionnelle.

### Installeur

Un installeur ClickOnce est disponible dans la **Release GitHub v1** du dépôt.
Il permet d'installer directement l'application sans Visual Studio.
L'installeur utilise l'API en ligne déployée sur AwardSpace.
Le mode opératoire pour utiliser l'API est dans le readme du dépôt : https://github.com/wrd-bnt/rest-mediatekdocuments

### Documentation technique

La documentation technique générée avec SandCastle Help File Builder est disponible :
- Dans le dossier doc/ du dépôt
- En ligne : http://mediatekdocs86.atwebpages.com/doc-mediatekdocuments/index.html
