module Domain.OptionTypes

type QuestionType =
        | TextField
        | RadioButton
        | CheckBox
        | Numeric

    type Status =
        | Open
        | InProgress
        | Done

    type ParticipantPosition =
        | Supervisor
        | Peer
        | Subordinate

