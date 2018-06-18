create table disciplines(
	id int auto_increment primary key,
	name varchar(100) not null
);

create table questions (
	id int auto_increment primary key,
    discipline_id int not null,
    question_text varchar(255) not null,
	constraint foreign key (discipline_id) references disciplines(id)
);

create table tests(
	id int auto_increment primary key,
    user_id int not null,
    score double not null,
    constraint foreign key (user_id) references users(id)
);

create table test_questions (
	test_id int not null,
    question_id int not null,
    constraint foreign key (test_id) references tests(id),
    constraint foreign key (question_id) references questions(id),
    primary key(test_id, question_id)
);


CREATE TABLE users (
  id int NOT NULL AUTO_INCREMENT,
  nickname varchar(50) NOT NULL,
  password varchar(50) NOT NULL,
  PRIMARY KEY (id)
);
