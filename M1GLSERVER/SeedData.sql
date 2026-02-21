-- Script d'insertion de données de test pour la base Dbmemoire
-- Données avec noms sénégalais

-- ============================================
-- 1. INSERTION DES FILIÈRES
-- ============================================
INSERT INTO "Filieres" ("Nom") VALUES 
('Informatique'),
('Gestion'),
('Droit')
ON CONFLICT DO NOTHING;

-- ============================================
-- 2. INSERTION DES ENCADREURS (3 encadreurs)
-- ============================================
INSERT INTO "Encadreurs" ("Nom", "Email") VALUES 
('Mactar Thioye', 'mactar.thioye@univ.sn'),
('Amadou Diop', 'amadou.diop@univ.sn'),
('Fatou Ndiaye', 'fatou.ndiaye@univ.sn')
ON CONFLICT DO NOTHING;

-- ============================================
-- 3. INSERTION DES ÉTUDIANTS (6 étudiants)
-- ============================================
INSERT INTO "Etudiants" ("Nom", "Prenom", "Email") VALUES 
('Sow', 'Ousmane', 'ousmane.sow@etudiant.sn'),
('Fall', 'Aissatou', 'aissatou.fall@etudiant.sn'),
('Sarr', 'Moussa', 'moussa.sarr@etudiant.sn'),
('Gueye', 'Mariama', 'mariama.gueye@etudiant.sn'),
('Ba', 'Ibrahima', 'ibrahima.ba@etudiant.sn'),
('Sy', 'Khady', 'khady.sy@etudiant.sn')
ON CONFLICT DO NOTHING;

-- ============================================
-- 4. INSERTION DES MÉMOIRES (4 mémoires)
-- ============================================
INSERT INTO "Memoires" ("Titre", "Auteur", "Contenu", "Date") VALUES 
(
    'Intelligence Artificielle appliquée à l''agriculture sénégalaise',
    'Ousmane Sow',
    'Ce mémoire explore l''utilisation de l''IA pour optimiser la production agricole au Sénégal.',
    NOW()
),
(
    'Digitalisation des PME au Sénégal : Enjeux et perspectives',
    'Aissatou Fall',
    'Analyse de la transformation digitale des petites et moyennes entreprises sénégalaises.',
    NOW() - INTERVAL '5 days'
),
(
    'Blockchain et traçabilité des produits agricoles',
    'Moussa Sarr',
    'Étude de l''implémentation de la technologie blockchain pour la traçabilité agricole.',
    NOW() - INTERVAL '10 days'
),
(
    'Droit foncier et développement rural au Sénégal',
    'Ibrahima Ba',
    'Analyse juridique des réformes foncières au Sénégal.',
    NOW() - INTERVAL '15 days'
)
ON CONFLICT DO NOTHING;

-- ============================================
-- VÉRIFICATION DES DONNÉES INSÉRÉES
-- ============================================
SELECT 'Filières insérées:' as Info, COUNT(*) as Total FROM "Filieres"
UNION ALL
SELECT 'Encadreurs insérés:', COUNT(*) FROM "Encadreurs"
UNION ALL
SELECT 'Étudiants insérés:', COUNT(*) FROM "Etudiants"
UNION ALL
SELECT 'Mémoires insérés:', COUNT(*) FROM "Memoires";
