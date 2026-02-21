-- Nettoyer les doublons et vérifier les données

-- 1. Supprimer les doublons d'encadreurs (garder le plus ancien)
DELETE FROM "Encadreurs" a USING "Encadreurs" b
WHERE a."Id" > b."Id" AND a."Email" = b."Email";

-- 2. Supprimer les doublons de filières
DELETE FROM "Filieres" a USING "Filieres" b
WHERE a."Id" > b."Id" AND a."Nom" = b."Nom";

-- 3. Vérifier les données
SELECT 'ENCADREURS:' as Info;
SELECT * FROM "Encadreurs" ORDER BY "Id";

SELECT 'FILIERES:' as Info;
SELECT * FROM "Filieres" ORDER BY "Id";

SELECT 'MEMOIRES:' as Info;
SELECT "Id", "Titre", "Auteur", "Statut", "FiliereId", "EncadreurId" FROM "Memoires" ORDER BY "Id";
