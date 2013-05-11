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
            replay = new MenuButton((int)X + 50, (int)(Y + StaticSize.Y - 50), "Replay", () => { Scene.Manager.SwitchScene(new GameScene(GameScene.CurrentLevel)); });
            Scene.AddEntity(replay);

            next = new MenuButton((int)X + 250, (int)(Y + StaticSize.Y - 50), "Next", () => { Scene.Manager.SwitchScene(new GameScene(GameScene.CurrentLevel)); });
            Scene.AddEntity(next);

            menu = new MenuButton((int)X + 175, (int)(Y + StaticSize.Y - 25), "Menu", () => { Scene.Manager.SwitchScene(new MenuScene()); });
            Scene.AddEntity(menu);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            replay.Position = new Vector2(X + 75, Y + StaticSize.Y - 100);
            next.Position = new Vector2(X + 350, Y + StaticSize.Y - 100);
            menu.Position = new Vector2(X + 215, Y + StaticSize.Y - 50);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteBatch.TextureWhite, BoundingBox, Color.Beige);
            spriteBatch.DrawString(Assets.UI, ((int)(GameScene).Time).ToString("000 s"), new Vector2(X + 100, Y + 50), Color.Black);

            for (int i = 0; i < GameScene.InitialStarCount; i++) {
                var pos = new Vector2(X + 100 + (i * 32), Y + 100);
                var color = Color.Gray;

                if (i < GameScene.CollectedStarCount) {
                    color = Color.Green;
                }

                spriteBatch.Draw(Assets.BubbleBlue, new Rectangle((int)pos.X, (int)pos.Y, 32, 32), color);
            }
        }

        public override void Delete() {
            Scene.RemoveEntity(replay);
            Scene.RemoveEntity(next);
            Scene.RemoveEntity(menu);
        }
    }
}