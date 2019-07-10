using RedApple.ConnectFramework.www;
using RedApple.DomainNet35.Quest;
using RedApple.GameFramework.config;
using RedApple.GameFramework.session;
using RedApple.GameFramework.thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.manager.QuestManager
{
    public class QuestManager:IQuestManager
    {

        private readonly RedSessionManager _redSessionManager;
        private readonly RedAppleServerSetting _serverSetting;
        private readonly RedThreadManager _threadManager;

        public QuestManager()
        {
            _redSessionManager = RedSessionManager.Instance;
            _serverSetting = RedConfigManager.Instance.GetConfig<RedAppleServerSetting>("RedAppleServerSetting");
            _threadManager = RedThreadManager.Instance;
        }


        public void GetNewQuest(Action<QuestResultModel> onComplate)
        {
            _threadManager.AddTherad<int, QuestResultModel>("RedApple.GameFramework.manager.QuestManager.GetNewQuest", GetNewQuest, 0, onComplate);
        }

        private void GetNewQuest(object theradStarter)
        {

            var _theradStarter = (TheradStarter<int, QuestResultModel>)theradStarter;
            try
            {
              
                using (var _webRequest = new RedWebRequest(_redSessionManager.SessionUser.RedToken))
                {
                    var quest = _webRequest.Get<DomainNet35.Quest.QuestTenant>($"{_serverSetting.Api}/redapple/gameadmin/StartQuest");

                    _threadManager.Enqueue(() => _theradStarter.Complate.Invoke(new QuestResultModel(quest)));
                    return;

                    //if (_loginresult.result == DomainNet35.Dto.request.GeneralResultType.OK)
                    //{
                       
                    //}
                    //if (_theradStarter.Complate != null)
                    //    _theradStarter.Complate.Invoke(new SessionResultModel(_loginresult.message));
                }
            }
            catch (Exception ex)
            {

                //if (_theradStarter.Complate != null)
                //    _theradStarter.Complate.Invoke(new LogoutUserResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
                _threadManager.Enqueue(() => _theradStarter.Error.Invoke(new ThreadException(ex)));
            }


        }

        public void StartGame(Action<QuestResultModel> onComplate)
        {
            _threadManager.AddTherad<int, QuestResultModel>("RedApple.GameFramework.manager.QuestManager.StartGame", StartGame, 0, onComplate);
        }

        private void StartGame(object theradStarter)
        {

            var _theradStarter = (TheradStarter<int, QuestResultModel>)theradStarter;
            try
            {

                using (var _webRequest = new RedWebRequest(_redSessionManager.SessionUser.RedToken))
                {
                    var quest = _webRequest.Get<DomainNet35.Quest.QuestTenant>($"{_serverSetting.Api}/redapple/gameadmin/StartGame");

                    _threadManager.Enqueue(() => _theradStarter.Complate.Invoke(new QuestResultModel(quest)));
                    return;

                    //if (_loginresult.result == DomainNet35.Dto.request.GeneralResultType.OK)
                    //{

                    //}
                    //if (_theradStarter.Complate != null)
                    //    _theradStarter.Complate.Invoke(new SessionResultModel(_loginresult.message));
                }
            }
            catch (Exception ex)
            {

                //if (_theradStarter.Complate != null)
                //    _theradStarter.Complate.Invoke(new LogoutUserResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
                _threadManager.Enqueue(() => _theradStarter.Error.Invoke(new ThreadException(ex)));
            }


        }

        public void SetAnswer(QuestDto questDto,Action<QuestResultModel> onComplate)
        {
            _threadManager.AddTherad<QuestDto, QuestResultModel>("RedApple.GameFramework.manager.QuestManager.SetAnswer", SetAnswer, questDto, onComplate);
        }

        private void SetAnswer(object theradStarter)
        {

            var _theradStarter = (TheradStarter<QuestDto, QuestResultModel>)theradStarter;
            try
            {
                var questDto = _theradStarter.DATA;
                using (var _webRequest = new RedWebRequest(_redSessionManager.SessionUser.RedToken))
                {
                    var quest = _webRequest.Get<DomainNet35.Quest.QuestTenant>($"{_serverSetting.Api}/redapple/gameadmin/SetAnswer?Answer="+questDto.Answer);

                    _threadManager.Enqueue(() => _theradStarter.Complate.Invoke(new QuestResultModel(quest)));
                    return;

                    //if (_loginresult.result == DomainNet35.Dto.request.GeneralResultType.OK)
                    //{

                    //}
                    //if (_theradStarter.Complate != null)
                    //    _theradStarter.Complate.Invoke(new SessionResultModel(_loginresult.message));
                }
            }
            catch (Exception ex)
            {

                //if (_theradStarter.Complate != null)
                //    _theradStarter.Complate.Invoke(new LogoutUserResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
                _threadManager.Enqueue(() => _theradStarter.Error.Invoke(new ThreadException(ex)));
            }


        }

        public void UsePromotionCode(PromotionDto promotionDto, Action<PromotionResultModel> onComplate)
        {
            _threadManager.AddTherad<PromotionDto, PromotionResultModel>("RedApple.GameFramework.manager.QuestManager.UsePromotionCode", UsePromotionCode, promotionDto, onComplate);
        }

        private void UsePromotionCode(object theradStarter)
        {
            var _theradStarter = (TheradStarter<PromotionDto, PromotionResultModel>)theradStarter;
            try
            {
                var promotionDto = _theradStarter.DATA;
                using (var _webRequest = new RedWebRequest(_redSessionManager.SessionUser.RedToken))
                {
                    var promotion = _webRequest.Get<DomainNet35.Quest.Promotion>($"{_serverSetting.Api}/redapple/gameadmin/UsePromotionCode?promotioncode=" + promotionDto.PromotionCode);

                    _threadManager.Enqueue(() => _theradStarter.Complate.Invoke(new PromotionResultModel(promotion)));
                    return;

                    //if (_loginresult.result == DomainNet35.Dto.request.GeneralResultType.OK)
                    //{

                    //}
                    //if (_theradStarter.Complate != null)
                    //    _theradStarter.Complate.Invoke(new SessionResultModel(_loginresult.message));
                }
            }
            catch (Exception ex)
            {
                if (_theradStarter.Complate != null)
                    _threadManager.Enqueue(() => _theradStarter.Complate.Invoke(new PromotionResultModel(ex.Message)));

                if (_theradStarter.Error != null)
                    _threadManager.Enqueue(() => _theradStarter.Error.Invoke(new ThreadException(ex)));
            }


        }

    }
}
