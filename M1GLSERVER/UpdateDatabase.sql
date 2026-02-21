-- Ajout des colonnes manquantes dans les tables

-- 1. Ajouter Statut, FiliereId, EncadreurId à la table Memoires
ALTER TABLE "Memoires" 
ADD COLUMN IF NOT EXISTS "Statut" VARCHAR(50) DEFAULT 'En attente',
ADD COLUMN IF NOT EXISTS "FiliereId" INTEGER,
ADD COLUMN IF NOT EXISTS "EncadreurId" INTEGER;

-- 2. Ajouter les contraintes de clés étrangères
ALTER TABLE "Memoires" 
ADD CONSTRAINT "FK_Memoires_Filieres" 
FOREIGN KEY ("FiliereId") REFERENCES "Filieres"("Id") ON DELETE SET NULL;

ALTER TABLE "Memoires" 
ADD CONSTRAINT "FK_Memoires_Encadreurs" 
FOREIGN KEY ("EncadreurId") REFERENCES "Encadreurs"("Id") ON DELETE SET NULL;

-- 3. Mettre à jour les mémoires existants avec des valeurs par défaut
UPDATE "Memoires" 
SET "Statut" = 'En attente' 
WHERE "Statut" IS NULL;

-- Assigner une filière par défaut (Informatique) aux mémoires existants
UPDATE "Memoires" 
SET "FiliereId" = (SELECT "Id" FROM "Filieres" WHERE "Nom" = 'Informatique' LIMIT 1)
WHERE "FiliereId" IS NULL;

-- Assigner un encadreur par défaut aux mémoires existants
UPDATE "Memoires" 
SET "EncadreurId" = (SELECT "Id" FROM "Encadreurs" LIMIT 1)
WHERE "EncadreurId" IS NULL;

-- Vérification
SELECT 'Mise à jour terminée' as Info;
SELECT * FROM "Memoires";
