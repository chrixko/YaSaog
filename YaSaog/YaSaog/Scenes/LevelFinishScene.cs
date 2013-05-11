﻿using Microsoft.Xna.Framework;
using YaSaog.Entities;
using YaSaog.Tweening;
using YaSaog.Utils.ActionLists.Actions;

namespace YaSaog.Scenes {

    public class LevelFinishScene : BaseScene {

        public GameScene CurrentScene { get; private set; }

        public LevelFinishScene(GameScene currentScene) {
            CurrentScene = currentScene;
        }

        public override void Init() {
            base.Init();

            var summary = new LevelSummary((int)((MainGame.Width / 2) - LevelSummary.StaticSize.X / 2), MainGame.Height, CurrentScene);
            summary.Actions.AddAction(new TweenPositionTo(summary, new Vector2(summary.X, (MainGame.Height / 2) - LevelSummary.StaticSize.Y / 2), 2f, Back.EaseOut), true);

            AddEntity(summary);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteBatch.TextureWhite, new Rectangle(0, 0, MainGame.Width, MainGame.Height), Color.Black * 0.7f);            

            base.Draw(spriteBatch);
        }
    }
}
