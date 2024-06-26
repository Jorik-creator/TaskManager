import React, { useEffect, useState } from 'react';
import { DayPilot, DayPilotScheduler, DayPilotModal } from 'daypilot-pro-react';
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7291'; // URL to my Backend

const Calendar = () => {
  const [events, setEvents] = useState([]);
  const [resources, setResources] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchEventsAndResources = async () => {
      try {
        const [eventsResponse, resourcesResponse] = await Promise.all([
          axios.get('/api/events'),
          axios.get('/api/resources'),
        ]);

        setEvents(eventsResponse.data.map(event => ({
          id: event.id,
          text: event.text,
          start: new DayPilot.Date(event.start),
          end: new DayPilot.Date(event.end),
          resourceId: event.resourceId,
        })));

        setResources(resourcesResponse.data.map(resource => ({
          id: resource.id,
          name: resource.name,
        })));
      } catch (error) {
        setError("Error fetching data: " + error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchEventsAndResources();
  }, []);

  const config = {
    viewType: "Days",
    days: DayPilot.Date.today().daysInMonth(),
    startDate: DayPilot.Date.today().firstDayOfMonth(),
    resources: resources,
    events: events,
    onTimeRangeSelected: async args => {
      const dp = args.control;
      const modal = await DayPilot.Modal.prompt("Create a new event:", "New Event");
      dp.clearSelection();

      if (modal.result) {
        try {
          const newEvent = {
            start: args.start.toString(),
            end: args.end.toString(),
            text: modal.result,
            resourceId: args.resource
          };

          const response = await axios.post('/api/events', newEvent);
          setEvents([...events, {
            id: response.data.id,
            start: new DayPilot.Date(response.data.start),
            end: new DayPilot.Date(response.data.end),
            text: response.data.text,
            resourceId: response.data.resourceId,
          }]);
        } catch (error) {
          setError("Error creating event: " + error.message);
        }
      }
    },
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div className="alert alert-danger">{error}</div>;
  }

  return <DayPilotScheduler {...config} />;
};

export default Calendar;
