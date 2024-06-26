import React from 'react';
import ReactDOM from 'react-dom/client';
import Calendar from './Calendar';

const container = document.getElementById('root');

const root = ReactDOM.createRoot(container);
root.render(
    <React.StrictMode>
        <Calendar />
    </React.StrictMode>
);
