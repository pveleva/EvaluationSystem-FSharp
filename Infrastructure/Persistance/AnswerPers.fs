module Infrastructure.Repositories.AnswerPers

open Domain.Entities
open FSharp.Data.Sql
open Infrastructure.DBContext

let answers = Context.Dbo.AnswerTemplate

let foundAnswerFunc id = query {
        for a in answers do
        where (a.Id = id)
        select (Some a)
        exactlyOneOrDefault
    }

let getAll = 
    task {
        let! res = 
            query {
                for answer in answers do
                select (answer)
            } |> Seq.executeQueryAsync
        return res |> Seq.map(fun app -> app.MapTo<Answer>())
    }

let getAnswerByIdAsync = fun id ->
   task {
       let! res =
           query {
               for answer in answers do
                where (answer.Id = id)
                select answer
               
           } |> Seq.headAsync
       
       return res.MapTo<Answer>()
   }

let create = fun (answer: Answer) ->
    task {
        let record = answers.Create()
        record.IsDefault <- answer.IsDefault
        record.Position <- answer.Position
        record.AnswerText <- answer.AnswerText
        record.IdQuestion <- answer.IdQuestion
         
        do! Context.SubmitUpdatesAsync()
        return! getAnswerByIdAsync record.Id 
    }

let update (answer: Answer) =
    task {
        match foundAnswerFunc answer.Id with
        | Some foundAnswer ->
            foundAnswer.IsDefault <- answer.IsDefault
            foundAnswer.Position <- answer.Position
            foundAnswer.AnswerText <- answer.AnswerText
            foundAnswer.IdQuestion <- answer.IdQuestion
            do! Context.SubmitUpdatesAsync()
            return "Update successful."
        | None ->
            return "The answer with the provided ID not found." 
    }

let delete id =
    task {
        match foundAnswerFunc id with
        | Some foundAnswer ->
            foundAnswer.Delete()
            do! Context.SubmitUpdatesAsync()
            return "Delete successful."
        | None ->
            return "The answer with the provided ID was not deleted." 
    }


