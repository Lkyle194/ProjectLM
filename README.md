🧠 Concept du LLMMORPG (Large Language MMORPG) Anti-Meta (par Laurent Ngea)
🎯 Objectif :
Créer un MMORPG où aucun build optimisé n’est reproductible, et où les compétences, les passifs et les objets sont attribués dynamiquement à chaque joueur par une IA comportementale qui observe son style de jeu réel.
L’idée est de tuer la méta, rendre les guides inutiles, et récompenser l’authenticité du joueur. Le joueur doit pouvoir jouer et évoluer en adéquation avec sa façon de jouer, l'IA lui proposera des compétences allant dans le sens du gameplay du joueur.
---
⚙️ Mécanique centrale : IA d’observation comportementale
🔍 Fonctionnement :
Chaque joueur a des filières comportementales invisibles (ex. : "protecteur", "fuyard", "opportuniste", "lâche", "héroïque", etc...).
Chaque action effectuée (combat, fuite, soin, exploration, émote, dialogue...) alimente une ou plusieurs barres d'XP invisibles liées à des compétences potentielles.
Ces barres peuvent aussi perdre de l’XP si le comportement du joueur devient incohérent avec la compétence.
---
🔓 Déblocage des compétences
📈 Système :
Quand une barre atteint 100%, la compétence devient “en attente de manifestation”.
Lors d’un événement contextuel (combat critique, moment social fort, exploration spéciale), cette compétence peut se déclencher automatiquement sous une forme ultime.
Ex : invocation immédiate d’un squelette géant pendant un combat tendu.
Une fois déclenchée, la compétence entre dans le kit du joueur en version normale : invocation d'un squelette mineur par exemple.
---
🌀 Exemples de progressions comportementales
🔹 Exemple 1 : Joueur opportuniste à distance
Classe : Guerrier
Se tient en retrait, fuit souvent, attaque quand les ennemis sont déjà blessés
→ Gagne de l’XP pour Invocation de Guerrier Squelette
→ Une fois débloquée et utilisée régulièrement au front, cela débloque Armure d’Os (le squelette devient une armure passive : 30 attaques réduites de 20%)
🔹 Exemple 2 : Joueur contemplatif / narratif
Classe : Barde
Ne combat pas, joue de la musique, fait des emotes, reste près des feux de camp
→ Gagne de l’XP pour la compétence Marque des Échos Oubliés (les monstres l’ignorent pendant un temps)
→ Gagne ensuite le passif Chaleur des Feux de Camp (buffs pour les alliés qui s’assoient avec lui)
---
💎 Objets à effets contextuels
🔁 Fonctionnement :
Les loots rares sont générés dynamiquement par l’IA en fonction du comportement récent du joueur ou d’un contexte émotionnel fort.
L’objet peut avoir un effet utile, neutre, voire pénalisant, selon l’attitude du joueur.
🔸 Exemples :
Epée d'ombre : Epée infligeant des dégats d'ombre et permettant a son Auto-Attaque de lancer des boules de feu ombrale mineure. Elle peut être looté sur un boss de type ombre qui a une grande quantité de phases d'invulnérabilité au CaC (Corps à corps) --> Loot d'une arme qui répond au besoin du joueur
Dague traîtresse : dégâts accrus en fuite, mais auto-inflige un saignement si tu attaques en groupe. L'arme pourrait être looté par un joueur qui a l'habitude de jouer en solo et/ou de fuir les combats de groupe perdu d'avance
Baguette du dernier rempart : se charge en soignant des alliés et explose en soin de zone lors d’un KO d’allié. Looté pour des healer qui ont beaucoup de morts dans leur équipe
Le loot de ces objets a effet spéciaux n'est pas systématique et se déclenche similairement à l'obtention des compétences, mais sans barre d'xp, plutôt un taux de loot qui évolue en fonction de la façon de jouer du joueur. Une fois looté le taux de loot se reset à sa valeur initiale et le joueur sera capable de le re looter de la même manière plus tard.
---
🧬 Évolution naturelle des compétences
Certaines compétences peuvent fusionner ou évoluer si l’usage change :
Ex : le sort d'invocation de squelette mineur peut débloquer une variante qui transforme le squelette a sa mort en une armure d'os (réduisant les dégats subis par le joueur) si l'IA détecte que le joueur combat côte à côte avec son invocation au CaC d'un monstre. Cette même variante peut débloquer une sous variante qui permet au joueur d'activer directement l'armure d'os sans avoir invoqué de squelette. Le joueur passerait d'un gameplay invocateur à un gameplay chevalier de la mort par exemple.
Les évolutions/variantes peuvent potentiellement être combinées entre elles ou changer completement le gameplay d'une compétence.
Ces évolutions sont aussi détectées et déclenchées automatiquement par l’IA selon les contextes de jeu.
---
🛡️ Système anti méta intégré
🔥 Mesures prévues :
L’IA détecte les comportements artificiels ou répétitifs (ex : spam d’actions incohérentes pour farmer une compétence).
Elle peut :
Réduire l’XP gagnée sur cette compétence
Proposer une compétence différente mais plus logique
Ou tout simplement ignorer certaines actions trop forcées
---
🎨 Ton intention de game design
> Tu veux créer un MMORPG vivant, qui reflète le joueur et non sa lecture d’un guide.
Les compétences doivent naître de son style, les loots de ses décisions, et l’évolution de ses actions, même inconscientes.
Tu veux que le joueur se découvre lui-même à travers le jeu, au lieu de chercher à optimiser quelque chose d’extérieur.
------------------
Si Je Démarre Une Nouvelle Discussion Pour Créer Une Nouvelle Compétence, Alors Il Faudra Répondre Avec Ce Template Ci Dessous :
🧠 TEMPLATE DE COMPÉTENCE – FORMAT STANDARDISÉ
---
🏷️ Nom de la compétence :
Nom évocateur et unique
---
🎯 Type :
(Défensif / Offensif / Contrôle / Furtivité / Social / Soin / Invocation…)
---
📖 Description courte :
Une phrase immersive décrivant la nature et l'effet général de la compétence.
---
📊 XP requise pour le déblocage :
Valeur numérique (souvent entre 500 et 1500 XP selon rareté et contexte)
Exemple : XP à atteindre : 1200
---
📈 Sources d’XP comportementale
(Liste d’actions précises qui peuvent faire monter la barre de la compétence, avec leurs conditions et leur valeur d’XP)
Action observée Condition(s) comportementale(s) XP gagnée
Exemple : Rester accroupi sans être vu pendant 10 sec Aucun combat actif +10 XP
… … …
---
❌ Contre-conditions (retrait d’XP)
(Comportements incohérents qui réduisent la progression vers la compétence)
Comportement incohérent Condition XP perdue
Exemple : Attaquer après une action de discrétion <5 sec après furtivité –20 XP
… … …
---
🔓 Déclenchement Ultime (manifestation)
(Quand la barre atteint 100%, dans quel contexte précis la compétence se manifeste pour la première fois ?)
Conditions contextuelles :
Exemple : Un allié est en danger
Le joueur n’attaque pas, reste proche, etc.
L’environnement est hostile ou tendu
Effet de l’Ultime :
> Décrire le pouvoir déclenché de façon spectaculaire : zone, durée, effets, cibles affectées, etc.
---
💠 Compétence normale intégrée après déclenchement :
(Résumé de l’effet “de base” une fois débloquée, utilisable dans le kit du joueur.)
---
🌀 Variantes / Transformations possibles
(Selon l’usage dominant dans les 10-15 premières activations)
Variante Condition comportementale dominante post-déblocage Effet spécifique
Variante A Usage hors combat / exploration Effet X
Variante B Usage en protection de soin Effet Y
Variante C Usage en fuite Effet Z
Variante D Usage social ou calme Effet W
---
