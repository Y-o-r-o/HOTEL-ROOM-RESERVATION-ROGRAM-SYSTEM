import React, { useState } from 'react';
import AdminLogin from 'components/AdminLogin';
import AdminReservation from 'components/AdminReservation';
import AdminRoom from 'components/AdminRooms';
import AdminAdministrator from 'components/AdminAdministrator';
import './style.scss';
import AdminHome from 'components/AdminHome';

function AdminPanel() {

  const [isLoading, setIsLoading] = useState(false);
  const [loggedInAs, setLoggedInValue] = useState("");
  const [selectedPage, setPage] = useState("home");

  function changePage(pageName) {
    setPage(pageName);
  }

  function logOut() {
    setIsLoading(true);
    setTimeout(function () {
      setLoggedInValue("");
    }, 50);
  }

  return (
    <>
      {loggedInAs != "" ?
        <>
          <div className="ui secondary menu">
            <div className="right menu">
              <a>
                Logged in as: <b><i>{loggedInAs}</i></b>
              </a>
            </div>
          </div>

          <div className="ui secondary pointing menu">
            {/* xddd koduks */}
            {
              selectedPage == "home" ?
                <a className="active item">
                  Home
                </a>
                :
                <a className="item" onClick={() => changePage("home")}>
                  Home
                </a>
            }

            {
              selectedPage == "rooms" ?
                <a className="active item">
                  Rooms
                </a>
                :
                <a className="item" onClick={() => changePage("rooms")}>
                  Rooms
                </a>
            }

            {
              selectedPage == "reservations" ?
                <a className="active item">
                  Reservations
                </a>
                :
                <a className="item" onClick={() => changePage("reservations")}>
                  Reservations
                </a>
            }

            {
              selectedPage == "administrators" ?
                <a className="active item">
                  Administrators
                </a>
                :
                <a className="item" onClick={() => changePage("administrators")}>
                  Administrators
                </a>
            }

            <div className="right menu">
              <a className="ui item" onClick={() => logOut()}>
                Logout
              </a>
            </div>

          </div>
          <div className="context ui segment">
            {
              selectedPage == "rooms" &&
              <AdminRoom />
            }
            {
              selectedPage == "home" &&
              <AdminHome />
            }
            {
              selectedPage == "reservations" &&
              <AdminReservation />
            }
            {
              selectedPage == "administrators" &&
              <AdminAdministrator loggedInAs={loggedInAs} />
            }
          </div >
        </>
        :
        <AdminLogin setLoggedInValue={setLoggedInValue} />
      }
    </>
  );
};
export default AdminPanel;