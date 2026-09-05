# Stock Voucher Manager

> **Rename recommended:** this repo is currently named `projet` ("project" in French) — one of the least descriptive names possible on a GitHub profile. Suggested name: **`stock-voucher-manager`** or **`inventory-in-out-tracker`**.

A Windows desktop application for tracking product stock movements using "vouchers" (`Bon`) — each voucher records a quantity of a product coming **in** (type `E`, entrée) or going **out** (type `S`, sortie), plus a unit price and date. Built with C# WinForms and SQL Server.

## Features
- Manage products (`Produit`): reference, designation, quantity in stock, purchase price
- Record stock-in and stock-out vouchers (`Bon`), each linked to a product
- CRUD screens: `GestionProduits`, `GestionBon`, `MenuProduit`

## Tech Stack
- C# / .NET Framework 4.8 (WinForms)
- ADO.NET (`System.Data.SqlClient`) for data access
- Microsoft SQL Server / SQL Server Express

## Architecture
| Layer | Folder | Responsibility |
|---|---|---|
| Business objects | `metiers/` | `Produit`, `Bon` domain classes |
| Data access | `dao/` | Raw SQL against SQL Server |
| Controllers | `controller/` | Bridges the UI to the DAO layer |
| UI | `projet/` | WinForms screens |

## Getting Started

### Prerequisites
- Visual Studio 2019+ with the ".NET desktop development" workload
- SQL Server or SQL Server Express

### Setup
1. Clone the repository.
2. Create a SQL Server database (e.g. `BDCommerciale`) with tables matching the `Produit` and `Bon` classes.
3. Update the connection string in [`dao/ConnexionVente.cs`](dao/ConnexionVente.cs) to point to **your own** SQL Server instance:
   ```csharp
   static string url = @"Server=YOUR_SERVER\SQLEXPRESS;Database=BDCommerciale;Trusted_Connection=True";
   ```
4. Open `projet.sln` in Visual Studio, restore/build the solution, and run.

## What to Fix Before Publishing
- [ ] **Rename the repo, solution, and inner UI project** — `projet` / `projet.sln` / `projet/` tell a recruiter nothing about what the app does
- [ ] **Hardcoded connection string** — move it into `App.config`
- [ ] There's a commented-out old connection string left in `ConnexionVente.cs` — remove dead code before publishing
- [ ] No screenshots or usage walkthrough yet

## License
Add a license of your choice (e.g. MIT) if you intend this to be public and reusable.
