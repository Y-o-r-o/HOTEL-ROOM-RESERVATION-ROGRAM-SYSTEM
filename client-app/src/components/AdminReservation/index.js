import React, { useEffect, useState } from 'react';
import data from '../../store/Data/reservations.json';
import Moment from 'moment';
import { useFormik } from 'formik';
import { Modal } from 'semantic-ui-react';
import DatePicker from 'react-datepicker';
import './style.scss';


function AdminReservation() {

    const [mstartDate, msetStartDate] = useState(new Date());
    const [mendDate, msetEndDate] = useState(new Date());

    const [items, setItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [open, setOpen] = useState(false)

    const [rid, setId] = useState("");
    const [rstartDate, setStartDate] = useState(new Date());
    const [rendDate, setEndDate] = useState(new Date());
    const today = new Date();

    useEffect(() => {
        setItems(data);
    }, []);

    const formikEdit = useFormik({
        enableReinitialize: true,
        initialValues: {
            startDate: rstartDate,
            endDate: rendDate,
        },
        onSubmit: value => {
            editItem(value);
        },
    });

    const editItem = (value) => {

        let item = items.find((item) => item.id == rid);

        item.id = rid;
        item.startDate = value.startDate;
        item.endDate = value.endDate;

        setTimeout(function () {
            setItems(items);
        }, 250);
    };

    const deleteItem = (id) => {
        showLoad();
        const newItems = items.filter((item) => item.id !== id);
        setItems(newItems);
    };

    async function showLoad() {
        setIsLoading(true);
        setTimeout(function () {
            setIsLoading(false);
        }, 250);
    };

    const changeDate = (date) => {
        const nextDate = new Date(date);
        nextDate.setDate(date.getDate() + 1);
        setStartDate(date);
        setEndDate(nextDate);
    }

    const mchangeDate = (date) => {
        const nextDate = new Date(date);
        nextDate.setDate(date.getDate() + 1);
        msetStartDate(date);
        msetEndDate(nextDate);
    }

    const CustomInput = ({ value, onClick }) => (
        <div className='calendar' onClick={onClick}>
            <input type='text' className="form-item" value={value} />
            <i className="bi bi-calendar-week"></i>
        </div>
    );

    const filter = () => {
        let filteredItems = items.filter((item) => !(
            new Date(item.startDate) >= mstartDate &&
            new Date(item.endDate) >= mendDate
        ));

        setItems(filteredItems);
    }

    return (
        <div id="content" className="p-4 p-md-5">

            <h2 className="mb-4">Reservations list</h2>

            <section className='filter d-flex '>
                <div className='filter-wrapper w-100 my-3'>

                    <div className='container space-fill filter-content'>
                        <DatePicker
                            dateFormat='yyyy/MM/dd'
                            selected={mstartDate}
                            onChange={mchangeDate}
                            startDate={mstartDate}
                            customInput={<CustomInput />}
                        />
                        <DatePicker
                            dateFormat='yyyy/MM/dd'
                            selected={mendDate}
                            onChange={date => msetEndDate(date)}
                            startDate={mendDate}
                            minDate={mstartDate}
                            customInput={<CustomInput />}
                        />
                        <button className='btn btn-primary' onClick={() => filter()}>Modify</button>
                    </div>

                </div>
            </section>


            <table className="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Additional features</th>
                        <th>Resident name</th>
                        <th>Resident email</th>
                        <th>Start date</th>
                        <th>End date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {items?.map((reservation) =>
                        <tr className='table-td'>
                            <td>{reservation.roomTypes.join(", ")}</td>
                            <td>{reservation.additionalFeatures.join(", ")}</td>
                            <td>{reservation.resident.name} {reservation.resident.surname}</td>
                            <td>{reservation.resident.email}</td>
                            <td>{Moment(reservation.startDate).format('YYYY-MM-DD hh:mm:ss')}</td>
                            <td>{Moment(reservation.endDate).format('YYYY-MM-DD hh:mm:ss')}</td>
                            {isLoading ?
                                <td>
                                    <button className='btn btn-primary btn-group-justified disabled'>
                                        Edit
                                    </button>
                                    <button className='btn btn-danger btn-group-justified disabled' id="delete">
                                        Remove
                                    </button>
                                </td>
                                :
                                <td>
                                    <Modal
                                        size='mini'
                                        open={open}
                                        onClose={() => setOpen(false)}
                                        onOpen={() => {
                                            setId(reservation.id);
                                            setStartDate(reservation.startDate);
                                            setEndDate(reservation.endDate);
                                            setOpen(true);
                                        }}
                                        trigger={
                                            <button className='btn btn-primary btn-group-justified'>
                                                Edit
                                            </button>}>
                                        <Modal.Content>
                                            <div>
                                                <div className="box-header with-border">
                                                    <h3 className="box-title">Edit reservation</h3>
                                                </div>
                                                <div className="box-body">

                                                    <form className="baseForm topmarg70 filter-content" onSubmit={formikEdit.handleSubmit}>


                                                        <div className="box-header with-border">
                                                            <i className="box-title">Start date:</i>
                                                        </div>
                                                        <DatePicker
                                                            dateFormat='yyyy/MM/dd'
                                                            onChange={changeDate}
                                                            startDate={formikEdit.values.startDate}
                                                            minDate={today}
                                                            customInput={<CustomInput />}
                                                            value={formikEdit.values.startDate.toString()}
                                                        />

                                                        <div className="box-header with-border">
                                                            <i className="box-title">End date :</i>
                                                        </div>
                                                        <DatePicker
                                                            dateFormat='yyyy/MM/dd'
                                                            onChange={date => setEndDate(date)}
                                                            startDate={formikEdit.values.endDate}
                                                            minDate={formikEdit.values.endDate}
                                                            customInput={<CustomInput />}
                                                            value={formikEdit.values.endDate.toString()}
                                                        />


                                                        <button
                                                            className='btn topmarg150 btn-primary btn-group-justified btn-lg'
                                                            onClick={() => setOpen(false)}>
                                                            Cancel
                                                        </button>

                                                        <button
                                                            className='btn topmarg150 btn-success btn-group-justified btn-lg'
                                                            onClick={() => {
                                                                editItem(formikEdit.values);
                                                                setOpen(false);
                                                            }}>
                                                            Save
                                                        </button>
                                                    </form>

                                                </div>
                                            </div>
                                        </Modal.Content>
                                    </Modal>
                                    <button className='btn btn-danger btn-group-justified' id="delete" onClick={() => deleteItem(reservation.id)}>
                                        Remove
                                    </button>
                                </td>
                            }
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};
export default AdminReservation;
