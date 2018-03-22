using AlexaSkill.Data;
using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public dynamic CodeGames(AlexaRequest alexaRequest)
        {
            dynamic response = null;

            switch (alexaRequest.Request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(alexaRequest);
                    break;
                case "IntentRequest":
                    response = IntentRequestHandler(alexaRequest);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(alexaRequest);
                    break;
            }

            return response;
        }

        private dynamic LaunchRequestHandler(AlexaRequest request)
        {
            //var response = new AlexaResponse("Welcome to Code Games.  What would you like to do today?");
            //response.Session.MemberId = request.Session.Attributes.MemberId;
            //response.Response.Card.Title = "Billing";
            //response.Response.Card.Content = "Billing and Invoicing";
            //response.Response.Reprompt.OutputSpeech.Text = "Would you like to do action1, action2, or action3?";
            //response.Response.ShouldEndSession = false;

            //return JsonConvert.SerializeObject(response);

            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Welcome to Code Games.  What would you like to do today?"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "AlexTest",
                        content = "Welcome"
                    },
                    shouldEndSession = false
                }
            };


        }

        private dynamic IntentRequestHandler(AlexaRequest request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Intent Request"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "AlexTest",
                        content = "StopOrCancel"
                    },
                    shouldEndSession = true
                }
            };

            //dynamic response = null;

            //switch (request.Request.Intent.Name)
            //{
            //    case "ActionOneIntent":
            //        response = ActionOneIntentHandler(request);
            //        break;
            //    case "ActionTwoIntent":
            //        response = ActionTwoIntentHandler(request);
            //        break;
            //    case "ActionThreeIntent":
            //        response = ActionThreeIntentHandler(request);
            //        break;
            //    case "AMAZON.CancelIntent":
            //    case "AMAZON.StopIntent":
            //        response = CancelOrStopIntentHandler(request);
            //        break;
            //    case "AMAZON.HelpIntent":
            //        response = HelpIntent(request);
            //        break;
            //}

            //return response;
        }

        private AlexaResponse HelpIntent(AlexaRequest request)
        {
            var response = new AlexaResponse("To use the code games skill, you can say, Alexa, I want to do action 1, 2 or 3. You can also say, Alexa, stop or Alexa, cancel, at any time to exit the code games skill. For now, do you want to do one of the actions?", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please select one, action 1,2 or 3?";
            return response;
        }

        private dynamic CancelOrStopIntentHandler(AlexaRequest request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Then why did you even bother?"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "AlexTest",
                        content = "StopOrCancel"
                    },
                    shouldEndSession = true
                }
            };
            //return new AlexaResponse("Thanks for listening, let's talk again soon.", true);
        }

        private AlexaResponse ActionOneIntentHandler(AlexaRequest request)
        {
            var output = new StringBuilder("Action 1 in progress. ");

            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse ActionTwoIntentHandler(AlexaRequest request)
        {
            var output = new StringBuilder("Action 2 in progress. ");

            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse ActionThreeIntentHandler(AlexaRequest request)
        {
            var output = new StringBuilder("Action 2 in progress. ");

            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse SessionEndedRequestHandler(AlexaRequest request)
        {
            return null;
        }
    }
}
