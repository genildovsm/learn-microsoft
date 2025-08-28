document.addEventListener('DOMContentLoaded', function(){

    var calendarEl = document.getElementById('calendar')
    
    var calendar = new FullCalendar.Calendar(calendarEl, {

        initialView: 'dayGridMonth',
        locale: 'pt-br',
        editable: false,
        showNonCurrentDates: false,
        fixedWeekCount: false,

        headerToolbar: {
            left: 'multiMonthYear,dayGridMonth,timeGridWeek,listWeek',
            center: 'title',
            right: 'today prev,next'
        },

        views: {
            multiMonthYear: {
                multiMonthMaxColumns: 1
            },
            timeGrid: {                
                titleFormat: {
                    day: 'numeric',
                    month: 'numeric',
                    year: 'numeric'
                },
                eventMaxStack: 1                             
            }
        },

        eventSourceFailure(error) {
            if (error instanceof JsonRequestError) {
            console.log(`Request to ${error.response.url} failed`)
            }
        },

        dayMaxEventRows: true,

        eventColor: '#204366ff',
        eventTextColor: 'white',
        eventBorderColor: '#3788d8',
        
        events: [
            {
                start: '2025-08-10 12:30:00',
                title: 'Reunião com as Diretorias Regionais',
                color: '#982345',
                textColor: '#fff'
            },
            {
                start: '2025-08-10 12:30:00', 
                end: '2025-08-10 15:30:00', 
                title: 'Visita técnica aos laboratórios'
            },
            {
                start: '2025-08-10 12:30:00', 
                title: 'Coleta de assinaturas'
            },
            {
                start: '2025-08-10 12:30:00', 
                title: 'Revisão do planejamento'
            },
            {
                start: '2025-08-10 12:30:00', 
                title: 'Pagamento de fornecedores'
            },
        ],

        // Callback disparado quando a visualização muda (next/prev/today)
        datesSet: function(dateInfo) {
            console.log('Visualização alterada:', dateInfo);
            console.log('Data início:', dateInfo.start);
            console.log('Data fim:', dateInfo.end);
            
            // Aqui você pode filtrar/carregar eventos específicos do período
            //filtrarEventosDoMes(dateInfo.start, dateInfo.end);
        },
    })

    calendar.render()

    document.getElementById('btn_refetch').onclick = ()=>{
        calendar.refetchEvents()
    }
})

