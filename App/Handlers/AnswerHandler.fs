module App.Handlers.AnswerHandler

open Giraffe
open Domain.Entities
open Microsoft.AspNetCore.Http
open App.Common.JsonApiResponse
open Infrastructure.Repositories.AnswerPers

let getAll = fun (next: HttpFunc) (ctx: HttpContext) ->
    task {        
        let! answers = getAll()
        let res = jsonApiWrap answers
        return! json res next ctx
    }

let create = fun (next: HttpFunc) (ctx: HttpContext) ->
    task {        
        let! answer = ctx.BindJsonAsync<Answer>()
        let! newAnswer = create answer
        return! json (jsonApiWrap newAnswer) next ctx
    }

let update = fun (next: HttpFunc) (ctx: HttpContext) ->
    task {        
        let! answer = ctx.BindJsonAsync<Answer>()
        let! newAnswer = update answer
        return! json (jsonApiWrap newAnswer) next ctx
    }

let delete = fun int (next: HttpFunc) (ctx: HttpContext) ->
    task {
        let! res = delete int 
        return! json (jsonApiWrap res) next ctx
    }

let answersGetRoutes: HttpHandler list = [
    route "/answer/getAll" >=> getAll
]

let answersPostRoutes: HttpHandler list = [
    route "/answer/create" >=> create
]

let answersPutRoutes: HttpHandler list = [
    route "/answer/update" >=> update
]

let answersDeleteRoutes: HttpHandler list = [
    routef "/answer/delete/%d" (fun int -> delete int)
]

