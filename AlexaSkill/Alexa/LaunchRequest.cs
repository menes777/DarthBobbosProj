using AlexaSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexaSkill.Alexa
{
    public class LaunchRequest
    {
        public LaunchRequest()
        {

        }

        public dynamic LaunchRequestHandler(AlexaRequest request)
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
        
    }
}