﻿using Microsoft.Xna.Framework;
using YaSaog.Entities.Menu;
using YaSaog.Scenes;

namespace YaSaog.Entities {

    public class LevelSummary : BaseEntity {

        private MenuButton replay;
        private MenuButton next;
        private MenuButton menu;
        
        public GameScene GameScene { get; private set; }

        public static Vector2 StaticSize = new Vector2(500, 300);

        public LevelSummary(int posX, int posY, GameScene scene) {
            X = posX;
            Y = posY;

            GameScene = scene;

            this.Size = StaticSize;
        }

        public override void Init() {
            replay = new MenuButton(0, 0, "Replay", () => { Scene.Manager.SwitchScene(new GameScene(GameScene.CurrentLevel)); });
            Scene.AddEntity(replay);

            var lvlIndex = Assets.Levels.IndexOf(GameScene.CurrentLevel);
            BaseScene nextScene = new LevelSelectionScene();
            if (lvlIndex + 1 < Assets.Levels.Count) {
                nextScene = new GameScene(Assets.Levels[lvlIndex + 1]);
            }

            next = new MenuButton(0, 0, "Next", () => { Scene.Manager.SwitchScene(nextScene); });
            Scene.AddEntity(next);

            menu = new MenuButton(0, 0, "Menu", () => { Scene.Manager.SwitchScene(new MenuScene()); });
            Scene.AddEntity(menu);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            replay.Position = new Vector2(X + 75, Y + StaticSize.Y - 120);
            next.Position = new Vector2(X + 350, Y + StaticSize.Y - 120);
            menu.Position = new Vector2(X + 215, Y + StaticSize.Y - 70);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Towel, BoundingBox, Color.White);
            spriteBatch.DrawString(Assets.UI, ((int)(GameScene).Time).ToString("000 s"), new Vector2(X + 220, Y + 50), Color.Black);

            for (int i = 0; i < GameScene.InitialStarCount; i++) {
                var pos = new Vector2(X + 200 + (i * 32), Y + 100);
                var color = Color.Gray;

                if (i < GameScene.CollectedStarCount) {
                    color = Color.White;
                }

                spriteBatch.Draw(Assets.Star, new Rectangle((int)pos.X, (int)pos.Y, 45, 45), color);
            }
        }

        public override void Delete() {
            Scene.RemoveEntity(replay);
            Scene.RemoveEntity(next);
            Scene.RemoveEntity(menu);
        }
    }
}