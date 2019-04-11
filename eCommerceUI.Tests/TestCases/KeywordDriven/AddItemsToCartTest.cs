using System;
using System.Collections.Generic;
using eCommerceUI.Core;
using OpenQA.Selenium;

namespace eCommerceUI.Tests.TestCases.KeywordDriven
{
    public class AddItemsToCartTest : ITest
    {
        private List<KeywordModel> m_model;
        private ILogger m_logger;
        private IWebDriverFacade m_driver;

        private Dictionary<string, Action<IWebDriverFacade, KeywordModel>> m_actions =
            new Dictionary<string, Action<IWebDriverFacade, KeywordModel>>
            {
                {"click", ClickAction},
                {"if-click", IfClickAction},
                {"scroll-and-click", MoveAndClickAction},
                {"back", BackAction}
            };

        public AddItemsToCartTest(IWebDriverFacade driver, IStepMapper<KeywordModel> mapper, ILogger logger, string filePath)
        {
            m_logger = logger;
            m_driver = driver;

            m_model = GetSteps(mapper, filePath);
        }

        public void Run()
        {
            m_driver.Start();

            foreach (var keywordModel in m_model)
            {
                try
                {
                    m_actions[keywordModel.Action](m_driver, keywordModel);
                    m_logger.Log(string.Format("Step '{0}' was passed", keywordModel.Step));
                }
                catch (Exception ex)
                {
                    m_logger.Log(string.Format("Step '{0}' was failed. \t Exception : {1}", keywordModel.Step, ex), LoggerLevel.Error);
                    break;
                }
            }
        }

        private static void ClickAction(IWebDriverFacade facade, KeywordModel model)
        {
            var xPathSelector = string.Format(model.Selector, model.Params.ToArray());
            var element = facade.FindElement(xPathSelector);
            if (element != null)
            {
                element.Click();
            }
            else
            {
                throw new NoSuchElementException(string.Format("Element by path {0} wasn't found.", xPathSelector));
            }
        }

        private static void IfClickAction(IWebDriverFacade facade, KeywordModel model)
        {
            var xPathSelector = string.Format(model.Selector, model.Params.ToArray());
            var element = facade.FindElement(xPathSelector, 2);
            if (element != null)
            {
                element.Click();
            }
        }

        private static void MoveAndClickAction(IWebDriverFacade facade, KeywordModel model)
        {
            var xPathSelector = string.Format(model.Selector, model.Params.ToArray());
            facade.MoveAndClickToElement(xPathSelector);
        }

        private static void BackAction(IWebDriverFacade facade, KeywordModel model)
        {
           facade.NavigateBack();
        }

        private List<KeywordModel> GetSteps(IStepMapper<KeywordModel> mapper, string path)
        {
            try
            {
                var lines = Utils.LoadCsvFile(path);
                return mapper.Map(lines);
            }
            catch (Exception ex)
            {
                m_logger.Log(string.Format("Data file by path {0} wasn't read. \t Exception: {1}", path, ex),LoggerLevel.Error);
            }

            return new List<KeywordModel>();
        }
    }
}