import React, { useState } from "react";
import { useContext } from "react";
import { SearchContext } from "store/SearchContext";
import { formatDateView } from "utils/formatDate";
import './style.scss';
import { Grid } from "semantic-ui-react";

function Thanks() {
    const [data, dispatch] = useContext(SearchContext);
    const { room, extra, step } = data;
    const [discount] = useState(10);

    const { price } = room;
    const sum = (acc, cur) => acc + cur;
    const total = extra.length ? extra.map(el => el.price).reduce(sum, 0) + price : price;


    if (data.step !== 0) return null;

    return (
        <section className='card-total'>
            <h1 className='mb-4'>
                Reservation is confirmed.
            </h1>
            <h2 className='mb-4'>
                Further information will be sent to your emal.
            </h2>
            <div className='d-flex justify-content-between'>
                <h3>
                    Order ID: 1300419121
                    Payment method: Visa/mastercard
                </h3>
            </div>
            <section className='card'>
                <Grid className='gridStyl' textAlign='left'>
                    <Grid.Row>
                        <Grid.Column width={6}>
                            <div>
                                <div className='font-weight-bold'>Product:</div>
                                <h3>
                                    {room.name}
                                </h3>
                                {extra && extra.map(item => (
                                    <div key={item.id}>
                                        <div>{item.name}</div>
                                    </div>
                                ))}
                            </div>
                        </Grid.Column>
                        <Grid.Column width={6}>
                            <div>
                                <div className='font-weight-bold mb-4'>Total payed:</div>
                                {discount > 0 && (
                                    <>
                                        <div>Discount € {total / discount}</div>
                                    </>
                                )}
                                <div className='mb-3'>
                                    <div />
                                    <div className='price '>€ {discount
                                        ? (total - discount / 100 * total).toFixed(2)
                                        : total}
                                    </div>
                                </div>
                            </div>
                        </Grid.Column>
                    </Grid.Row>
                </Grid>

            </section>
            <section className='card mb-4'>
                <div className='price mb-4'>More details</div>

                <div className='d-flex mb-4'>
                    <div>
                        <div className='font-weight-bold'>Check in</div>
                        <div>From 12.00h</div>
                    </div>
                    <div>
                        <div className='font-weight-bold'>Check out</div>
                        <div>Before 12.00h</div>
                    </div>
                </div>
                <div className='mb-3'>
                    <div className='font-weight-bold'>Reservation date</div>
                    <div>From <strong>{formatDateView(data.checkin)}</strong> to <strong>{formatDateView(data.checkout)}</strong></div>
                </div>
                <div className='mb-3'>
                    <div className='font-weight-bold'>People</div>
                    <div>{data.adults} Adults</div>
                </div>
            </section>
            <button className='btn btn-primary btn-group-justified'
                onClick={ev => {
                    dispatch({
                        type: 'changeSearch',
                        payload: {
                            step: 1
                        }
                    })
                }}
            >
                &lt; back
            </button>
        </section>
    )
}

export default Thanks
