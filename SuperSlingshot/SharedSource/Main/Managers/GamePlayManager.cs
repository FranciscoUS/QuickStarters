﻿using System;
using System.Collections.Generic;
using System.Text;
using SuperSlingshot.Scenes;
using WaveEngine.Common;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace SuperSlingshot.Managers
{
    public class GamePlayManager : Service
    {
        private Scene menuScene;

        public bool IsPaused { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();
            this.menuScene = new MenuScene();
        }

        public override void OnActivated()
        {
            base.OnActivated();
            this.IsPaused = false;
        }

        public void PauseGame()
        {
            if (!this.IsPaused)
            {
                this.IsPaused = true;
                var gameScene = WaveServices.ScreenContextManager.CurrentContext.FindScene<GameScene>();
                gameScene?.Pause();

                WaveServices.ScreenContextManager.Push(new ScreenContext(this.menuScene));
            }
        }

        public void ResumeGame()
        {
            if(this.IsPaused)
            {
                this.IsPaused = false;
                var gameScene = WaveServices.ScreenContextManager.CurrentContext.FindScene<GameScene>();
                gameScene?.Resume();

                WaveServices.ScreenContextManager.Pop(false);
            }
        }
    }
}
