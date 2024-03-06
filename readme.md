## Documentation Back-end

### Vue d'ensemble de l'Architecture

L'application EventManager est structurée en utilisant l'architecture N-Layer.

1. **EventManager.Business** : Contient la logique métier de l'application.

2. **EventManager.Business.Contracts** : Définit les interfaces et les contrats utilisés par la couche métier. Cette séparation facilite la modularité et le test de l'application.

3. **EventManager.DAL (Data Access Layer)** : Responsable de la communication avec la base de données. Cette couche gère les requêtes et manipule les données.

4. **EventManager.DAL.Contracts** : Contient les interfaces et les contrats pour la couche d'accès aux données. Permet une abstraction de la logique d'accès aux données.

5. **EventManager.Models** : Définit les objets et les modèles de données utilisés dans l'ensemble de l'application. 

6. **EventManager.Presentation** : Représente la couche de présentation, responsable de l'interaction avec l'utilisateur.

### Exécution de l'Application

#### Prérequis
- .NET 7.0 SDK installé
- SQL Server installé et accessible
- Azure Functions Core Tools si nécessaire

#### Configuration de la Base de Données
Avant de lancer l'application, assurez-vous de configurer correctement la chaîne de connexion à la base de données. Cette configuration se trouve dans le fichier `program.cs`.

Modifier la chaîne de connexion pour correspondre à votre environnement :

```csharp
options.UseSqlServer("VotreChaîneDeConnexion");
```

#### Application de Migrations
La couche `EventManager.DAL` contient des migrations pour la base de données. Pour appliquer ces migrations :

1. Ouvrez une invite de commandes ou un terminal.
2. Naviguez jusqu'au répertoire contenant le projet `EventManager.DAL`.
3. Exécutez la commande suivante pour appliquer les migrations à votre base de données :
   ```
   dotnet ef database update -s .\EventManager.Presentation\ -p .\EventManager.DAL\
   ```

#### Lancement de l'Application
Après avoir configuré la base de données et appliqué les migrations, l'application est prête à être exécutée. Pour lancer l'application Azure Function :

1. Naviguez jusqu'au répertoire contenant le projet principal (où se trouve `program.cs`).
2. Exécutez la commande suivante :
   ```
   dotnet run
   ```

Cette commande démarre le host Azure Function et l'application est maintenant en attente de requêtes.