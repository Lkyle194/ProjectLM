# 🧪 POC MMORPG Anti‑Meta – Unreal Engine 5.6 + ONNX LLM

## 🎯 Objectif
Intégrer un POC Unreal Engine 5.6 permettant :

- Observation des comportements du joueur (logs en background)
- XP invisible dans des filières comportementales
- Déblocage automatique de compétences via événements clés (version ultime)
- Intégration d’un LLM/Inference via ONNX pour la couche IA
- Détection d’optimisation artificielle (anti‑meta)

## ⚙️ Architecture logicielle
1. **Analyse comportementale** : script C++/Blueprint observant distances, fuites, soins, emotes et interactions. Ces actions alimentent des filières comportementales invisibles (ex : « Fuyard », « Protecteur »…). Chaque filière possède une barre d’XP cachée.
2. **Gestion des XP invisibles** : incrémentation via `IncrementXP("InvocationSquelette", value)` et décrémentation en cas d’incohérence pour détecter un comportement artificiel.
3. **Déclenchement de compétence ultime** : sur événement (combat critique, interaction VRP…), probabilité d’activation ultime. Exemple : invocation squelette géante, soin massif, charme spectral.
4. **Objets/contextual loot** : loots dynamiques liés aux comportements récents et effet narratif unique (description en JSON et fonction attachée au joueur).
5. **Anti‑meta** : détection de patterns anormaux, baisse des gains XP ou renvoi vers compétences alternatives.

## 🧠 Intégration LLM/Inference ONNX
### A. Runtime ONNX via Neural Network Engine (NNE)
- Utiliser le plugin **NNEngine** (ONNX Runtime) compatible UE 5.6.
- Modèles ONNX quantifiés pour une VRAM réduite.
- Exemple C++ :
```cpp
OnnxModel* model = new OnnxModel("Path/Model.onnx", EOnnxProvider::GPU_DirectML, 0);
model->Init();
model->BindInputFloatArray(...);
model->Run();
model->GetOutputXXX();
```
- Accessible en Blueprint via `UOnnxModelWrapper` et nœuds BP.

### B. Bonnes pratiques UE 5.6
- Fichier ONNX ≤ 2 GB (pas de split supporté).
- Importer le plugin **NNEngine** et configurer les modèles dans `Content/Models`.
- Packaging PC/Consoles avec inference CPU/GPU DirectML.
- Code Python uniquement pour l’export ; runtime en C++/Blueprint pur.

### C. Alternative plugin LLM
- **UnrealAiConnector** : appels ChatGPT/Gemini via Blueprint/C++ si ONNX est trop lourd (non 100 % local).

## 📦 Étapes de mise en œuvre
1. **Setup projet UE 5.6** : créer un projet C++ + Blueprint et activer le plugin NNEngine.
2. **Import et test d’un modèle ONNX** : placer le modèle quantifié dans `Content/Models`, créer BP ou C++ `UOnnxModelWrapper`, puis tester avec un tensor d’entrée simple.
3. **Système comportemental** : créer une classe `UBehaviorTracker` exposant `AddBehaviorXP(BehaviorTag, amount)` et stockant l’XP par filière.
4. **Compétences potentielles** : data asset listant chaque compétence avec `BehaviorTag`, seuil de déblocage, conditions d’ultime, cooldown et blueprint d’effet normal/ultime.
5. **Vérification & déclenchement** : à chaque action, mettre à jour l’XP et vérifier le seuil. Sur événement, appliquer une chance d’ultime, puis ajouter la compétence au joueur.
6. **Loots contextuels** : fonction `GenerateLoot(ContextTags)` stockant la description JSON et les effets dans l’inventaire.
7. **Anti‑meta** : suivi de fréquence des actions et pénalités d’XP avec feedback (“Tu explores trop le hack, IA t’oriente ailleurs.”).

## 📘 Documentation pour ChatGPT/Codex
- Fichiers à fournir : `BehaviorTracker.h/.cpp`, `SkillDataAsset.uasset`, `OnnxModelComponent.h/.cpp`, `GameplayEventHandler` pour les triggers, exemples de blueprint et de logique de loot.
- Explications claires sur le binding Blueprint/C++, l’initialisation et l’exécution ONNX, la sauvegarde persistante d’XP et la gestion de compétences exposée en Blueprint.

## 📌 Liens utiles
- Guide NNEngine UE 5.3‑5.6 (forums, LinkedIn, Reddit…)
- Microsoft sample ONNX + NNI plugin
