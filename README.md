# MediatekDocuments

Ce dépôt présente les fonctionnalités ajoutées à l'application d'origine disponible ici : https://github.com/CNED-SLAM/MediaTekDocuments (Le readme de ce dépôt contient la présentation de l'application d'origine).

Cette évolution a été développée en C# sous Visual Studio. Elle ajoute une authentification avec gestion des droits d'accès selon le service de l'employé, une amélioration de la base de données avec des triggers, l'intégration de logs, des tests unitaires et un déploiement en ligne.

## Présentation

Les fonctionnalités ajoutées sont les suivantes : authentification avec gestion des droits, amélioration de la BDD (table suivi, triggers, tables service et utilisateur), méthode ParutionDansAbonnement, logs Serilog et tests unitaires.

## Authentification

L'application démarre désormais sur une fenêtre d'authentification. L'employé saisit son login et son mot de passe. 

<img width="320" height="143" alt="Fenetre_de_connexion" src="https://github.com/user-attachments/assets/4eeb5bf8-5e23-44b5-bc71-2740be2c1352" />


Selon son service d'appartenance, les droits d'accès sont différents.

**Service Administratif (ADM) :** accès total à toutes les fonctionnalités de l'application.

**Service Prêts (PRE) :** accès en consultation uniquement aux onglets Livres, DVD et Revues. L'onglet "Parutions des revues" est masqué.

<img width="1101" height="860" alt="Capture d&#39;écran 2026-03-27 070619" src="https://github.com/user-attachments/assets/a270d177-9a18-4ffa-83a0-1c794d525a19" />


**Service Culture (CUL) :** accès refusé. Un message informe l'employé que ses droits ne sont pas suffisants, puis l'application se ferme.

<img width="478" height="165" alt="Capture d&#39;écran 2026-03-27 070957" src="https://github.com/user-attachments/assets/62f941a8-3617-477f-a61a-52cbb01f64f6" />

## Améliorations de la base de données

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

<img width="1660" height="459" alt="Capture d&#39;écran 2026-03-27 072228" src="https://github.com/user-attachments/assets/5847427f-152a-47c4-948c-d89a07837da2" />

## Méthode ParutionDansAbonnement

La méthode statique ParutionDansAbonnement a été ajoutée dans la classe Exemplaire du package model. Elle reçoit 3 dates en paramètre (date de commande, date de fin d'abonnement, date de parution) et retourne vrai si la date de parution est comprise entre les deux autres dates.

## Logs

Serilog a été intégré dans la classe Access pour enregistrer les erreurs et événements dans un fichier logs/log.txt et dans la console.

## Tests unitaires

4 tests unitaires ont été créés avec MSTest sur les classes du package model :
- ExemplaireTests : 1 test de la méthode ParutionDansAbonnement
- ServiceTests : 2 tests de la classe Service
- UtilisateurTests : 1 test de la classe Utilisateur

<img width="1201" height="447" alt="Capture d&#39;écran 2026-03-27 071927" src="https://github.com/user-attachments/assets/a2322ae4-0dc2-4c88-9686-6fc7f277446a" />

## La base de données

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
- Dans Access.cs (dal), vérifier que l'URL pointe vers le local : private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
- Lancer l'application avec **Démarrer**

Les identifiants de connexion sont fournis dans la fiche de réalisation professionnelle.

### Installeur

Un installeur ClickOnce est disponible dans le dossier install/ du dépôt. 
Il permet d'installer directement l'application sans Visual Studio. 
L'installeur utilise l'API en ligne déployée sur AwardSpace. 
Le mode opératoire pour utiliser l'API est dans le readme du dépôt : https://github.com/wrd-bnt/rest-mediatekdocuments

### Documentation technique

La documentation technique générée avec SandCastle Help File Builder est disponible dans le dossier doc/Help/ du dépôt.
