import React, { useEffect, useState } from 'react';
import './style.scss';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';
import { Line } from 'react-chartjs-2/dist';
import DatePicker from 'react-datepicker';
import data from '../../store/Data/reservations.json';
import moment from 'moment';



function AdminHome() {

    const [items, setItems] = useState([]);
    const [mstartDate, msetStartDate] = useState(new Date());
    const [mendDate, msetEndDate] = useState(new Date().getTime() + 7 * 24 * 60 * 60 * 1000);
    const [labels, setLabels] = useState([]);

    useEffect(() => {
        setItems(data);
    }, []);

    const mchangeDate = (date) => {
        const nextDate = new Date(date);
        nextDate.setDate(date.getDate() + 7);
        msetStartDate(date);
        msetEndDate(nextDate);
    }


    const setLabelsValues = () => {
        let newLabels = [];

        const diffTime = Math.abs(mendDate - mstartDate);
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

        for (let i = 0; i <= diffDays; i++) {
            newLabels.push(moment(new Date(new Date(mstartDate.getTime() + i * 24 * 60 * 60 * 1000))).format('YYYY-MM-DD'));
        }

        setLabels(newLabels);
    }

    const filter = () => {
        let filteredItems = items.filter((item) => !(
            new Date(item.startDate) >= mstartDate &&
            new Date(item.endDate) >= mendDate
        ));

        setItems(filteredItems);
    }

    ChartJS.register(
        CategoryScale,
        LinearScale,
        PointElement,
        LineElement,
        Title,
        Tooltip,
        Legend
    );


    const options = {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            }
        },
        hover: {
            mode: 'index',
            intersec: false
        },
        scales: {
            x: {
                title: {
                    display: true,
                    text: 'Reservations date'
                }
            },
            y: {
                title: {
                    display: true,
                    text: 'Reservations count'
                },
                ticks: {
                    stepSize: 1
                }
            }
        }
    };

    const chartData = {
        labels,
        datasets: [
            {
                label: 'BasicForTwo',
                data: labels.map((l) => items.filter((i) => i.roomTypes.toString().includes('BasicForTwo') && new Date(i.startDate.split('T')[0]) <= new Date(l) && new Date(i.endDate.split('T')[0]) >= new Date(l)).length),
                borderColor: 'rgb(255, 99, 132, 0.5)',
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
            },
            {
                label: 'MiniForTwo',
                data: labels.map((l) => items.filter((i) => i.roomTypes.toString().includes('MiniForTwo') && new Date(i.startDate.split('T')[0]) <= new Date(l) && new Date(i.endDate.split('T')[0]) >= new Date(l)).length),
                borderColor: 'rgb(0,128,0, 0.5)',
                backgroundColor: 'rgba(0,128,0, 0.2)',
            },
            {
                label: 'VipForTwo',
                data: labels.map((l) => items.filter((i) => i.roomTypes.toString().includes('VipForTwo') && new Date(i.startDate.split('T')[0]) <= new Date(l) && new Date(i.endDate.split('T')[0]) >= new Date(l)).length),
                borderColor: 'rgb(128,128,0, 0.5)',
                backgroundColor: 'rgba(128,128,0, 0.2)',
            },
            {
                label: 'VipForFamily',
                data: labels.map((l) => items.filter((i) => i.roomTypes.toString().includes('VipForFamily') && new Date(i.startDate.split('T')[0]) <= new Date(l) && new Date(i.endDate.split('T')[0]) >= new Date(l)).length),
                borderColor: 'rgb(53, 162, 235, 0.5)',
                backgroundColor: 'rgba(53, 162, 235, 0.2)',
            },
            {
                label: 'VipForFriends',
                data: labels.map((l) => items.filter((i) => i.roomTypes.toString().includes('VipForFriends') && new Date(i.startDate.split('T')[0]) <= new Date(l) && new Date(i.endDate.split('T')[0]) >= new Date(l)).length),
                borderColor: 'rgb(0,0,128, 0.5)',
                backgroundColor: 'rgba(0,0,128, 0.2)',
            },
        ],
    };

    const CustomInput = ({ value, onClick }) => (
        <div className='calendar' onClick={onClick}>
            <input type='text' className="form-item" value={value} />
            <i className="bi bi-calendar-week"></i>
        </div>
    );


    return (
        <div className="p-4 p-md-5">

            <h2 className="mb-4">Reservations per date chart</h2>

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
                            maxDate={new Date(new Date(mstartDate.getTime() + 7 * 24 * 60 * 60 * 1000))}
                            customInput={<CustomInput />}
                        />
                        <button className='btn btn-primary' onClick={() => {
                            setLabelsValues();
                            filter();
                        }}>Modify</button>
                    </div>

                </div>
            </section>
            <Line options={options} data={chartData} />
        </div>
    );
};
export default AdminHome;