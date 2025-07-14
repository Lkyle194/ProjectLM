# Recherche LLM léger pour intégration dans Unreal Engine 5.6

## Question d'origine
> fais une recherche sur internet pour savoir quel est le meilleur LLM open source, gratuit, leger, qui consomme peu de RAM/VRAM/CPU que je pourrais utiliser en local et coupler avec l'unreal engine 5.6 de sorte qu'au final on puisse integrer le LLM dans le jeu dans l'installer de tous ceux qui installent le jeu. Ca doit être transparent pour le joueur, il ne doit pas installer de LLM externe qui se connecte au jeu... NON il faut que tout soit intégré au jeu

## Réponse résumée
Voici une liste de modèles open‑source adaptés à une intégration locale :

### Mistral 7B
- ~7,3 B paramètres
- Licence Apache‑2.0
- Performances proches de LLaMA 13B pour un poids moindre
- Nécessite environ 6 GB RAM et 6 GB VRAM

### TinyLlama (1.1 B)
- Modèle ultra‑léger avec une bonne efficacité
- Fonctionne sur < 2 GB RAM/VRAM
- Idéal sur CPU ou GPU basique

### MobiLlama (0.5 B)
- Conçu pour les appareils contraints
- ~1 GB RAM/VRAM
- Transparent pour une intégration sur appareil embarqué

### GEB‑1.3B
- Modèle bilingue optimisé pour le CPU
- ≈3–4 GB RAM/VRAM
- Bon rapport performance/ressources sur CPU

## Choix selon la configuration
| Cas d’usage | Modèle recommandé | RAM/VRAM estimée |
|-------------|------------------|-----------------|
| Minimum (CPU uniquement) | **MobiLlama** | ~1 GB |
| GPU modeste | **TinyLlama** | ~2 GB |
| Équilibre performance/taille | **Mistral 7B** | ~6 GB |
| CPU puissant | **GEB‑1.3B** | ~4 GB |

## Conseils d'intégration Unreal Engine 5.6
1. Convertir le modèle en **ONNX** (ou TensorRT/CoreML).
2. Utiliser **ONNX Runtime** embarqué dans le jeu pour éviter toute dépendance externe.
3. Appliquer une **quantification** (int8 ou 4 bits) pour réduire la consommation mémoire.
4. Inclure les poids convertis directement dans l'installation du jeu.

## Étapes suivantes
- Sélectionner un modèle (TinyLlama pour un démarrage rapide).
- Convertir puis quantifier le modèle choisi.
- Intégrer via plugin Unreal (C++/Blueprint) en mode serveur interne.
- Mesurer l'impact sur les ressources (RAM, CPU, latence) et ajuster.
