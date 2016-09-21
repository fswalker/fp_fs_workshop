#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.SlackNotificationHelper

Target "Slack" <| fun _ ->

    let webhookUrl = "https://hooks.slack.com/services/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"
        
    SlackNotification webhookUrl (fun p ->
        { p with
            Attachments = 
            [| 
                { SlackNotificationAttachmentDefaults with
                    Fallback = "Hello F# developers!"
                    Text = "Hello F# developers! :-)"
                    Color = "#028fcc"
                }
            |]
        })
    |> printfn "Result: %s"

RunTargetOrDefault "Slack"
