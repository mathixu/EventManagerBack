## Documentation Back-end

### Vue d'ensemble de l'Architecture

L'application EventManager est structur�e en utilisant l'architecture N-Layer.

1. **EventManager.Business** : Contient la logique m�tier de l'application.

2. **EventManager.Business.Contracts** : D�finit les interfaces et les contrats utilis�s par la couche m�tier. Cette s�paration facilite la modularit� et le test de l'application.

3. **EventManager.DAL (Data Access Layer)** : Responsable de la communication avec la base de donn�es. Cette couche g�re les requ�tes et manipule les donn�es.

4. **EventManager.DAL.Contracts** : Contient les interfaces et les contrats pour la couche d'acc�s aux donn�es. Permet une abstraction de la logique d'acc�s aux donn�es.

5. **EventManager.Models** : D�finit les objets et les mod�les de donn�es utilis�s dans l'ensemble de l'application. 

6. **EventManager.Presentation** : Repr�sente la couche de pr�sentation, responsable de l'interaction avec l'utilisateur.

### Ex�cution de l'Application

#### Pr�requis
- .NET 7.0 SDK install�
- SQL Server install� et accessible
- Azure Functions Core Tools si n�cessaire

#### Configuration de la Base de Donn�es
Avant de lancer l'application, assurez-vous de configurer correctement la cha�ne de connexion � la base de donn�es. Cette configuration se trouve dans le fichier `program.cs`.

Modifier la cha�ne de connexion pour correspondre � votre environnement :

```csharp
options.UseSqlServer("VotreCha�neDeConnexion");
```

#### Application de Migrations
La couche `EventManager.DAL` contient des migrations pour la base de donn�es. Pour appliquer ces migrations :

1. Ouvrez une invite de commandes ou un terminal.
2. Naviguez jusqu'au r�pertoire contenant le projet `EventManager.DAL`.
3. Ex�cutez la commande suivante pour appliquer les migrations � votre base de donn�es :
   ```
   dotnet ef database update -s .\EventManager.Presentation\ -p .\EventManager.DAL\
   ```

#### Lancement de l'Application
Apr�s avoir configur� la base de donn�es et appliqu� les migrations, l'application est pr�te � �tre ex�cut�e. Pour lancer l'application Azure Function :

1. Naviguez jusqu'au r�pertoire contenant le projet principal (o� se trouve `program.cs`).
2. Ex�cutez la commande suivante :
   ```
   dotnet run
   ```

Cette commande d�marre le host Azure Function et l'application est maintenant en attente de requ�tes.