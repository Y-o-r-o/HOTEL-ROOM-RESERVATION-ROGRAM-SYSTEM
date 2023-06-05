import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.scss';
import BookingSteps from './components/BookingSteps/index';
import NotFound from './components/NotFound/index';
import DefaultLayout from './layouts/default/index';
import BookingRoutes from './routes/booking-routes';
import React from 'react';
import AdminPanel from 'components/AdminPanel';

function App() {
  return (
    <Router>
      <Switch>
        <BookingRoutes path="/" exact component={BookingSteps} />
        
        <Route path="/admin">
          <DefaultLayout>
            <AdminPanel />
          </DefaultLayout>
        </Route>

        <Route>
          <DefaultLayout>
            <NotFound />
          </DefaultLayout>
        </Route>

      </Switch>
    </Router>
  );
}

export default App;
