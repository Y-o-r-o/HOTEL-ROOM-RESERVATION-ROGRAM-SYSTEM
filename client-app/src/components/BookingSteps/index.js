import React, { useContext, useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import { SearchContext } from '../../store/SearchContext';
import Activities from './../Activities/index';
import Register from './../Register/index';
import Rooms from './../Rooms/index';
import Thanks from 'components/Thanks';

function BookingSteps() {
    const [data, dispatch] = useContext(SearchContext);
    const path = useLocation();

    useEffect(() => {

        if (data.step === 1 && data.finished) {
            dispatch({
                type: 'changeSearch',
                payload: {
                    extra: [],
                    room: {},
                    finished: false
                }
            });
        }
    }, []);

    return (
        <>
            { data.step > 0 ? 
            <section className='mb-5 mt-5 ml-2'>
                <h1>Rooms</h1>
                <p>Plan your perfect stay at our hotel</p>
                <img src={`/images/book-steps-${data.step}.png`} alt='' className='booking-step' />
            </section> : null
            }
            <Rooms />
            <Thanks />
            <Activities />
            <Register />
        </>
    )
}

export default BookingSteps;
