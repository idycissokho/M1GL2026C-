-- Supprimer les doublons en gardant uniquement les enregistrements avec le plus petit ID

-- 1. Supprimer les doublons de Filières
DELETE FROM "Filieres" 
WHERE "Id" NOT IN (
    SELECT MIN("Id") 
    FROM "Filieres" 
    GROUP BY "Nom"
);

-- 2. Supprimer les doublons d'Encadreurs
DELETE FROM "Encadreurs" 
WHERE "Id" NOT IN (
    SELECT MIN("Id") 
    FROM "Encadreurs" 
    GROUP BY "Email"
);

-- 3. Vérifier les résultats
SELECT 'Filières restantes:' as Info, COUNT(*) as Total FROM "Filieres";
SELECT * FROM "Filieres" ORDER BY "Id";

SELECT 'Encadreurs restants:' as Info, COUNT(*) as Total FROM "Encadreurs";
SELECT * FROM "Encadreurs" ORDER BY "Id";
